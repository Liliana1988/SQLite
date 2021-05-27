using Foundation;
using SQLite.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;


[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace SQLite.iOS
{
    class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConecction()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);

        }
    }
}