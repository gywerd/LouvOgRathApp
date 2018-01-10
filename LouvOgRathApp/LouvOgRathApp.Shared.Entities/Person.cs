using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LouvOgRathApp.Shared.Entities
{
    public class Person
    {
        #region Fields
        int id;
        string name;
        string address;
        string place;
        int zip;
        string town;
        int ssn;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Person() { }

        /// <summary>
        /// Constructor used when reading to DB
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="name">string</param>
        /// <param name="adr">string</param>
        /// <param name="place">string</param>
        /// <param name="zip">int</param>
        /// <param name="town">string</param>
        /// <param name="ssn">int</param>
        public Person(int id, string name, string adr, int zip, string town, int ssn, string place = null)
        {
            this.id = id;
            this.name = name;
            this.address = adr;
            this.place = place;
            this.zip = zip;
            this.town = town;
            this.ssn = ssn;
        }
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set
            {
                try
                {
                    id = value;
                }
                catch (ArgumentOutOfRangeException aor)
                {
                    MessageBox.Show(Convert.ToString(aor));
                    throw;
                }
                catch (ArgumentNullException an)
                {
                    MessageBox.Show(Convert.ToString(an));
                    throw;
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                    throw;
                }

            }
        }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Place { get => place; set => place = value; }
        public int Zip
        {
            get => zip;
            set
            {
                try
                {
                    zip = value;
                }
                catch (ArgumentOutOfRangeException aor)
                {
                    MessageBox.Show(Convert.ToString(aor));
                    throw;
                }
                catch (ArgumentNullException an)
                {
                    MessageBox.Show(Convert.ToString(an));
                    throw;
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                    throw;
                }

            }
        }

        public string Town { get => town; set => town = value; }
        public int Ssn { get => ssn; set => ssn = value; }
        #endregion
    }
}
