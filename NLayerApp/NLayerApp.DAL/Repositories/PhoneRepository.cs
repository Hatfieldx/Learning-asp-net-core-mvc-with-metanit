﻿using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NLayerApp.DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private MobileContext db;

        public PhoneRepository(MobileContext context)
        {
            this.db = context;
        }

        public IEnumerable<Phone> GetAll()
        {
            return db.Phones;
        }

        public Phone Get(int id)
        {
            return db.Phones.Find(id);
        }

        public void Create(Phone book)
        {
            db.Phones.Add(book);
        }

        public void Update(Phone book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Phone> Find(Func<Phone, Boolean> predicate)
        {
            return db.Phones.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Phone book = db.Phones.Find(id);
            if (book != null)
                db.Phones.Remove(book);
        }
    }
}
