using GitMS.Models;
using GitMS.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace GitMS
{

    public static class NodeStore
    {
        private static FileSystemWatcher fsw;
        private static string _nodesDirectory = @"C:\Users\pete.field\Documents\Visual Studio 2012\Projects\GitMS\GitMS\data\nodes";

        public static NodeRepository Repository { 
            get; 
            set;
        }

        public static void Register(HttpConfiguration config) {

            Repository = new NodeRepository(_nodesDirectory);

            fsw = new FileSystemWatcher(_nodesDirectory);
            fsw.Changed += file_Changed;
            fsw.EnableRaisingEvents = true;
            Repository.Init();

        }

        static void file_Changed(object sender, FileSystemEventArgs e) {
            Repository.Init();
        }
    }
}
