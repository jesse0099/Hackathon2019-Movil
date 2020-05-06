using System;
using System.IO;
using Android.OS;
using SQLite;
using UISampleApp.Interfaces;
using UISampleApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(UISampleApp.Droid.Implementations.SQLitePlatform))]
namespace UISampleApp.Droid.Implementations
{
    public class SQLitePlatform : ISQLitePlatform
    {
        public string GetPath() {
            var dbName =Constantes.DatabaseFileName;
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),dbName);

            return path;
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }
    }
}