using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using TestAutoPost.Models;

namespace TestAutoPost.DAL
{
    public class UserData
    {
        public bool IsValid(string username, string password)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("TestAutoPost");

            var collection = database.GetCollection<User>("Users");

            var query = Query.And(
                Query.EQ("UserName", username),
                Query.EQ("Password", password));
            var user = collection.FindOne(query);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}