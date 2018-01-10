using LouvOgRathApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.ServerSide.DataAccess
{
    public class Repository
    {
        #region fields
        private Executor executor;
        private const string connectionString = @"Data Source=10.205.44.39,49172;Initial Catalog=LouvOgRath.Gywerd;User ID=Aspit;Password=Server2012";
        #endregion

        #region Constructors
        /// <summary>
        /// empty constructor
        /// </summary>
        public Repository()
        {
            executor = new Executor(connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// reads all rows in database - returns a list
        /// </summary>
        /// <returns>List<Person></returns>
        public List<Person> GetAllPersons()
        {
            List<Person> persons = new List<Person>();
            string query = "SELECT * FROM Persons";
            //using stored procedure instead of specific query
            //string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = Convert.ToString(reader["Name"]);
                string adr = Convert.ToString(reader["Address"]);
                string place = Convert.ToString(reader["Place"]);
                int zip = Convert.ToInt32(reader["Zip"]);
                string town = Convert.ToString(reader["Town"]);
                int ssn = Convert.ToInt32(reader["Ssn"]);
                Person p = new Person(id, name, adr, zip, town, ssn, place);
                persons.Add(p);
            }
            return persons;
        }

        /// <summary>
        /// reads all rows in database - returns a list
        /// </summary>
        /// <returns>List<Secretary></returns>
        public List<Secretary> GetAllSecretaries(List<Person> person)
        {
            List<Secretary> secs = new List<Secretary>();
            string query = "SELECT * FROM Secretaries";
            //using stored procedure instead of specific query
            //string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int pid = Convert.ToInt32(reader["Person"]);
                Person p = GetPerson(person, pid);
                Secretary sec = new Secretary(id, p);
                secs.Add(sec);
            }
            return secs;
        }

        public List<Lawyer> GetAllLawyers(List<Person> person)
        {
            List<Lawyer> laws = new List<Lawyer>();
            string query = "SELECT * FROM Lawyers";
            //using stored procedure instead of specific query
            //string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int pid = Convert.ToInt32(reader["Person"]);
                Person p = GetPerson(person, pid);
                Lawyer law = new Lawyer(id, p);
                laws.Add(law);
            }
            return laws;
        }

        public List<Client> GetAllClients(List<Person> person)
        {
            List<Client> cls = new List<Client>();
            string query = "SELECT * FROM Clients";
            //using stored procedure instead of specific query
            //string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int pid = Convert.ToInt32(reader["Person"]);
                Person p = GetPerson(person, pid);
                Client cl = new Client(id, p);
                cls.Add(cl);
            }
            return cls;
        }

        public List<Case> GetAllCases()
        {
            List<Case> css = new List<Case>();
            string query = "SELECT * FROM Case";
            //using stored procedure instead of specific query
            //string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string cKind = Convert.ToString(reader["CaseKind"]);
                int lid = Convert.ToInt32(reader["Lawyer"]);
                int clid = Convert.ToInt32(reader["Client"]);
                Case cs = new Case(id, cKind, lid, clid);
                css.Add(cs);
            }
            return css;
        }

        public List<MeetingSummary> GetAllMeetingSummaries()
        {
            List<MeetingSummary> mss = new List<MeetingSummary>();
            string query = "SELECT * FROM Case";
            //using stored procedure instead of specific query
            //string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int cid = Convert.ToInt32(reader["Case"]);
                int sid = Convert.ToInt32(reader["Lawyer"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                string sum = Convert.ToString(reader["Summary"]);
                MeetingSummary ms = new MeetingSummary(id, cid, sid, date);
                mss.Add(ms);
            }
            return mss;
        }

        private Person GetPerson(List<Person> person, int pid)
        {
            Person pers = new Person();
            foreach (Person p in person)
            {
                if (p.Id == pid)
                {
                    pers = p;
                }
            }
            return pers;
        }
        #endregion
    }
}
