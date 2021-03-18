﻿
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
                        var subject = _fscontext.Subjects.Single(x => x.SubjectID == d.Subject.SubjectID);
                        var user = _fscontext.Users.Single(x => x.UserID == d.User.UserID);
                        d.User = user;
                        d.Subject = subject;

                        _fscontext.Add(d);
                        _fscontext.SaveChanges();
                        return true;
                    case Card c:
                        var deckOfCards1 = _fscontext.DecksOfCards.Single(x => x.DeckOfCardsID == c.DeckOfCards.DeckOfCardsID);
                        c.DeckOfCards = deckOfCards1;

                        _fscontext.Add(c);
                        _fscontext.SaveChanges();
                        return true;
                    case Like l:
                        var user1 = _fscontext.Users.Single(x => x.UserID == l.User.UserID);
                        var deckOfCards = _fscontext.DecksOfCards.Single(x => x.DeckOfCardsID == l.DeckOfCards.DeckOfCardsID);
                        l.User = user1;
                        l.DeckOfCards = deckOfCards;

                        _fscontext.Add(l);
                        _fscontext.SaveChanges();
                        return true;
                    default:
                        break;
                }
                /*_fscontext.Add(o);
                _fscontext.SaveChanges();*/
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool Update(Object o)
        {
            try
            {
                _fscontext.Update(o);
                _fscontext.SaveChanges();

                return true;
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
                        if (s.SubjectID != 0)
                            return _fscontext.DecksOfCards
                                .Where(d => d.Subject.SubjectID == s.SubjectID)
                                .Include(d => d.User);
                        else
                            return _fscontext.Subjects
                                .Where(su => su.Year == s.Year);
                    case DeckOfCards d:
                        return _fscontext.DecksOfCards
                            .Where(deck => deck.DeckOfCardsID == d.DeckOfCardsID)
                            .Include(deck => deck.Cards)
                            .Include(deck => deck.User)
                            .Include(deck => deck.Subject);
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
