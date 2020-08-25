using SharpSvn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchRepository
{
    class SVN : Repository
    {
        private static SvnClient client;
        private String serverPath;

        public bool Init(string serverPath)
        {
            client = new SvnClient();

            //var cred = new System.Net.NetworkCredential("kou", "kou");
            //client.Authentication.DefaultCredentials = cred;

            this.serverPath = serverPath;

            return true;
        }

        public HashSet<string> GetLogByTime(DateTime startDateTime, DateTime endDateTime)
        {
            long[] revisions = GetVersion(startDateTime, endDateTime);

            if (revisions == null)
            {
                return null;
            }

            SvnRevisionRange range = new SvnRevisionRange(revisions[0], revisions[1]);
            SvnLogArgs logArgs = new SvnLogArgs()
            {
                Limit = 0,
                Range = range,
                RetrieveAllProperties = true,
            };

            Collection<SvnLogEventArgs> logs;
            client.GetLog(new Uri(serverPath), logArgs, out logs);

            HashSet<string> fetchFiles = new HashSet<string>();

            foreach (var log in logs)
            {
                foreach (var changeItem in log.ChangedPaths)
                {
                    if (changeItem.Action == SvnChangeAction.Modify
                        || changeItem.Action == SvnChangeAction.Add
                        || changeItem.Action == SvnChangeAction.Replace)
                    {
                        fetchFiles.Add(ChangeToLocalPath(changeItem.Path));
                    }
                }
            }
            return fetchFiles;
        }

        private string ChangeToLocalPath(string filePath)
        {
            string pjFolderName = Path.GetFileName(serverPath.TrimEnd(Path.DirectorySeparatorChar));
            string fileRelativePath = filePath.Substring(filePath.IndexOf(pjFolderName));

            return fileRelativePath;
        }
    
        /// <summary>
        /// because the library use UTC datetime, so can not believe datetime 
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        private long[] GetVersion(DateTime startDateTime, DateTime endDateTime)
        {
            SvnRevisionRange range = new SvnRevisionRange(new SvnRevision(startDateTime.AddDays(-1)), new SvnRevision(endDateTime.AddDays(2)));
            SvnLogArgs logArgs = new SvnLogArgs()
            {
                Limit = 0,
                Range = range,
                RetrieveAllProperties = true,
            };

            Collection<SvnLogEventArgs> logs;
            client.GetLog(new Uri(serverPath), logArgs, out logs);

            long[] revisions = new long[2] { -1, -1 };
            foreach (var log in logs)
            {
                if (log.Time.ToLocalTime().Date >= startDateTime.Date && revisions[0] == -1)
                {
                    revisions[0] = log.Revision;
                }
                revisions[1] = log.Revision;

                if (log.Time.ToLocalTime().Date > endDateTime.Date)
                {
                    break;
                }
            }
            if (revisions[0] == -1) return null;

            return revisions;
        }

    }
}