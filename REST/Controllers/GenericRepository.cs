
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using REST.Data;
using REST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{
    public class GenericRepository : IGenericRepository
    {
        private readonly FlashcardsContext _fscontext = new FlashcardsContext();

        public bool Add(Object o)
        {
            try
            {
                switch (o)
                {
                    case User u:
                        _fscontext.Add(o);
                        _fscontext.SaveChanges();
                        return true;
                    case DeckOfCards d:
                        d.Subject = _fscontext.Subjects.Single(x => x.SubjectID == d.Subject.SubjectID);
                        d.User = _fscontext.Users.Single(x => x.Username == d.User.Username );
                        
                        List<Card> cards = d.Cards;

                        _fscontext.Add(d);
                        _fscontext.SaveChanges();

                        int lastDeckOfCardsID = _fscontext.DecksOfCards.Max(x => x.DeckOfCardsID);

                        foreach (Card c in cards)
                        {
                            c.DeckOfCards.DeckOfCardsID = lastDeckOfCardsID;
                            _fscontext.Add(c);
                        }

                        return true;
                    case Card c:
                        c.DeckOfCards = _fscontext.DecksOfCards.Single(x => x.DeckOfCardsID == c.DeckOfCards.DeckOfCardsID);

                        _fscontext.Add(c);
                        _fscontext.SaveChanges();
                        return true;
                    case Like l:
                        l.User = _fscontext.Users.Single(x => x.Username == l.User.Username);
                        l.DeckOfCards = _fscontext.DecksOfCards.Single(x => x.DeckOfCardsID == l.DeckOfCards.DeckOfCardsID);

                        _fscontext.Add(l);
                        _fscontext.SaveChanges();
                        return true;
                    case Comment c:
                        c.User = _fscontext.Users.Single(x => x.Username == c.User.Username);
                        c.DeckOfCards = _fscontext.DecksOfCards.Single(x => x.DeckOfCardsID == c.DeckOfCards.DeckOfCardsID);

                        _fscontext.Add(c);
                        _fscontext.SaveChanges();
                        return true;
                    case SubComment s:
                        s.Comment = _fscontext.Comments.Single(x => x.CommentID == s.Comment.CommentID);
                        s.SubCommentedBy = _fscontext.Users.Single(x => x.Username == s.SubCommentedBy.Username);

                        _fscontext.Add(s);
                        _fscontext.SaveChanges();
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal object Login(User u)
        {
            try
            {
                var user = _fscontext.Users
                    .Where(us => us.Username == u.Username || us.Email == u.Username)
                    .FirstOrDefault();
                if (user == null) return "Ne postoji taj username u bazi";

                if (user.Password != u.Password) return "Neispravan password";

                return DashboardInfo(user);

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        internal object DashboardInfo(User user)
        {
            try
            {
                List<DeckOfCards> decks = _fscontext.DecksOfCards.Where(d => d.User.UserID == user.UserID).ToList();
                int br = 0;
                foreach (DeckOfCards d in decks)
                {
                    br += (int)_fscontext.Likes.Where(l => l.DeckOfCards.DeckOfCardsID == d.DeckOfCardsID).Distinct().Count();
                }

                return new JObject(

                    new JProperty("User", new JObject(JObject.FromObject(_fscontext.Users.Where(u => u.UserID == user.UserID).SingleOrDefault()))),
                    new JProperty("Comments_Made", (int)_fscontext.Comments.Where(comm => comm.User.UserID == user.UserID).Distinct().Count()
                                   + (int)_fscontext.SubComments.Where(sub => sub.SubCommentedBy.UserID == user.UserID).Distinct().Count()),
                    new JProperty("Cards_Created", decks.Count()),
                    new JProperty("Likes_Got", br)

                );
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public object GetByIdWithPage(Object obj, int page)
        {
            try
            {
                    
                switch (obj)
                {
                    case Subject s:
                        var counters = _fscontext.DecksOfCards
                            .Where(deck => deck.Subject.SubjectID == s.SubjectID)
                                  .Count();
                        var pagess = counters % 8 > 0 ? counters / 8 + 1 : counters / 8;
                        return
                            new JObject(
                                new JProperty(
                                    "Decks", new JArray(JArray.FromObject(_fscontext.DecksOfCards
                            .Where(deck => deck.Subject.SubjectID == s.SubjectID)
                             .Select(fullDeck => new DeckOfCards()
                             {
                                 DeckOfCardsID = fullDeck.DeckOfCardsID,
                                 Subject = fullDeck.Subject,
                                 Name = fullDeck.Name,
                                 Date = fullDeck.Date,                                
                                 User = fullDeck.User,
                                 NumberOfLikes = fullDeck.Likes.Count(),
                                 LikedByUser = fullDeck.Likes.SingleOrDefault(l => l.User.UserID == 5) != null ? true : false
                             })
                            .Skip((page - 1) * 8)
                            .Take(8)
                            .ToList()))),
                                new JProperty("Pages", pagess)
                            );
                    case DeckOfCards d:
                        var counterd = _fscontext.DecksOfCards
                                  .Where(deck => EF.Functions.Like(deck.Name, $"%{d.Name}%"))
                                  .Count();
                        var pagesd = counterd % 8 > 0 ? counterd / 8 + 1 : counterd / 8;
                        return new JObject(
                            new JProperty("Decks", new JArray(
                                JArray.FromObject(_fscontext.DecksOfCards
                               .Where(deck => EF.Functions.Like(deck.Name, $"%{d.Name}%"))
                              .Select(fullDeck => new DeckOfCards()
                              {
                                  DeckOfCardsID = fullDeck.DeckOfCardsID,
                                  Subject = fullDeck.Subject,
                                  Name = fullDeck.Name,
                                  Date = fullDeck.Date,
                                  User = fullDeck.User,
                                  NumberOfLikes = fullDeck.Likes.Count(),
                                  LikedByUser = fullDeck.Likes.SingleOrDefault(l => l.User.UserID == 5) != null ? true : false
                              })
                              .Skip((page - 1) * 8)
                              .Take(8)
                              .ToList()))),
                              new JProperty("Pages", pagesd)
                              );
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object Register(User user)
        {
            try
            {
                var u = _fscontext.Users
                    .Where(us => us.Email == user.Email).FirstOrDefault();

                if (u == null) return $"Ne postoji {user.Email} u bazi";
                if (!string.IsNullOrEmpty(u.DateRegistered.ToString())) return "Ovaj user je vec registrovan";

                var name = _fscontext.Users
                    .Where(usname => usname.Username == user.Username).FirstOrDefault();
                if (name != null) return "Taj username je već zauzet";

                u.Username = user.Username;
                u.Password = user.Password;
                u.DateRegistered = DateTime.Now;

                _fscontext.Update(u);
                _fscontext.SaveChanges();

                return DashboardInfo(u);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public bool Update(Object o)
        {
            try
            {
                switch (o)
                {
                    case User u:
                        User userDatabase = _fscontext.Users.Where(x => x.Username == u.Username).FirstOrDefault<User>();

                        if (userDatabase != null)
                        {
                            if (u.Password != userDatabase.Password)
                                return false;
                            userDatabase.Password = u.Email;

                            _fscontext.Update(userDatabase);
                            _fscontext.SaveChanges();
                            return true;
                        }
                        return false;
                    case DeckOfCards d:
                        DeckOfCards deckOfCards = _fscontext.DecksOfCards.Where(x => x.DeckOfCardsID == d.DeckOfCardsID).FirstOrDefault<DeckOfCards>();
                        List<Card> cardsDatabase = _fscontext.Cards.Where(x => x.DeckOfCards.DeckOfCardsID == d.DeckOfCardsID).ToList();
                        List<Card> cardsUser = d.Cards;
                        
                        if (deckOfCards  != null)
                        {
                            deckOfCards.Name = d.Name;
                            _fscontext.Update(deckOfCards);
                            _fscontext.SaveChanges();

                            for (int i=0; i<cardsDatabase.Count; i++)
                            {
                                for(int j=0; j<cardsUser.Count; j++)
                                {
                                    if (cardsDatabase[i].CardID == cardsUser[j].CardID)
                                    {
                                        cardsDatabase[i].TextFront = cardsUser[j].TextFront;
                                        cardsDatabase[i].TextBack = cardsUser[j].TextBack;
                                        _fscontext.Update(cardsDatabase[i]);
                                        _fscontext.SaveChanges();
                                    }
                                }
                            }

                            return true;
                        }
                        return false;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Object o)
        {
            try
            {
                switch (o)
                {
                    case DeckOfCards d:
                        var cards = _fscontext.Cards
                            .Where(c => c.DeckOfCards.DeckOfCardsID == d.DeckOfCardsID);

                        foreach(Card card in cards)
                            _fscontext.Remove(card);
                        _fscontext.Remove(d);
                        break;
                    default:
                        return false;
                }
                _fscontext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Object GetAll(Object o)
        {
            throw new NotImplementedException();
        }

        public object GetById(object o)
        {
            try
            {
                switch (o)
                {
                    case User u:
                        return _fscontext.Users
                            .Where(us => us.UserID == u.UserID);
                    case Subject s:
                            return _fscontext.Subjects
                                .Where(su => su.Year == s.Year);
                    case DeckOfCards d:
                        return _fscontext.DecksOfCards
                            .Where(deck => deck.DeckOfCardsID == d.DeckOfCardsID)
                             .Select(fullDeck => new DeckOfCards()
                             {
                                 DeckOfCardsID = fullDeck.DeckOfCardsID,
                                 Subject = fullDeck.Subject,
                                 User = fullDeck.User,
                                 Cards = fullDeck.Cards,
                                 NumberOfLikes = fullDeck.Likes.Count(),
                                 LikedByUser = fullDeck.Likes.SingleOrDefault(l => l.User.UserID == 5) != null ? true : false,
                             })
                             .Include(fullDeck => fullDeck.Comments)
                                .ThenInclude(comm => comm.SubComments)
                             .FirstOrDefault();
                    default:
                        return null;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
