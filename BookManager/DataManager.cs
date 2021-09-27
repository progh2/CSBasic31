﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookManager
{
    public class DataManager
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();

        static DataManager()
        {
            Load();
        }

        private static void Load()
        {
            try
            {
                string booksOutput = File.ReadAllText(@"./Book.xml");
                XElement bookElement = XElement.Parse(booksOutput);
                Books = (from item in bookElement.Descendants("book")
                         select new Book()
                         {
                             Isbn = item.Element("isbn").Value,
                             Name = item.Element("name").Value,
                             Publisher = item.Element("publisher").Value,
                             Page = int.Parse(item.Element("page").Value),
                             isBorrowed = item.Element("isBorrowed").Value != "0" ? true : false,
                             UserId = int.Parse(item.Element("userId").Value),
                             UserName = item.Element("userName").Value
                         }).ToList<Book>();

                string userOutput = File.ReadAllText(@"./User.xml");
                XElement userElement = XElement.Parse(userOutput);
                Users = (from item in userElement.Descendants("user")
                         select new User()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<User>();
            }
            catch (FileNotFoundException exception)
            {
                Save();
            }
        }

        private static void Save()
        {
            string booksOutput = "";
            booksOutput += "<books>\n";
            foreach( var item in Books)
            {
                booksOutput += "<book>\n";
                booksOutput += "  <isbn>" + item.Isbn + "</isbn>\n";
                booksOutput += "  <name>" + item.Name + "</name>\n";
                booksOutput += "  <publisher>" + item.Publisher + "</publisher>\n";
                booksOutput += "  <page>" + item.Page + "</page>\n";
                booksOutput += "  <borrowedAt>" + item.BorrowedAt.ToLongDateString() + "</borrowedAt>\n";
                booksOutput += "  <isBorrowed>" + (item.isBorrowed ? "1" : "0" )+ "</isBorrowed>\n";
                booksOutput += "  <userId>" + item.UserId + "</userId>\n";
                booksOutput += "  <userName>" + item.UserName + "</userName>\n";
                booksOutput += "</book>\n";
            }
            booksOutput += "</books>\n";
            File.WriteAllText(@"./Books.xml", booksOutput);

            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach (var item in Users)
            {
                usersOutput += "<user>\n";
                usersOutput += "  <id>" + item.Id + "</id>\n";
                usersOutput += "  <name>" + item.Name + "</name>\n";
                usersOutput += "</user>\n";
            }
            usersOutput += "</users>\n";
            File.WriteAllText(@"./Users.xml", usersOutput);
        }
    }
}
