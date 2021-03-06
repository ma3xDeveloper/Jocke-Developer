﻿namespace TrafalgarSquare.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TrafalgarSquare.Data.Repositories;
    using TrafalgarSquare.Data.Repositories.Contracts;
    using TrafalgarSquare.Models;

    public class TrafalgarSquareData : ITrafalgarSquareData
    {

        private readonly ITrafalgarSquareDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TrafalgarSquareData(ITrafalgarSquareDbContext context)
        {
            this.context = context;
        }

        public ITrafalgarSquareDbContext Context
        {
            get { return this.context; }
        }

        public IGenericRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IGenericRepository<Post> Posts
        {
            get { return this.GetRepository<Post>(); }
        }

        public IGenericRepository<UsersReportedPosts> UsersReportedPosts
        {
            get { return this.GetRepository<UsersReportedPosts>(); }
        }

        public IGenericRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }


        public IGenericRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }
    }
}
