using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WPF_APP_CRUD
{
    class Book
    {
        public Book(int price, string title)
        {
            this.Title = title;
            this.Price = price;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }
    }
}
