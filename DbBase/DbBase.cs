using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbBase
{
    public class DbBase
    {
        #region Singleton

        private static DbBase _instance = null;

        public DbBase()
        {
        }

        public static DbBase GetInstance()
        {
            if (_instance == null)
                _instance = new DbBase();

            return _instance;
        }
        #endregion

        #region Select

        public string GetAll<T>(T entity)
        {
            String Select = "";
            String Where = "";
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;


            foreach (PropertyInfo prop in props)
            {
                if (String.IsNullOrEmpty(Select))
                {
                    Select = "SELECT " + prop.Name + " ";
                }
                else
                {
                    Select += " ," + prop.Name + " ";
                }


                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (typeProp.Contains("Int"))
                {
                    if (Convert.ToInt64(valueOf) > 0)
                    {
                        if (String.IsNullOrEmpty(Where))
                        {
                            Where = " WHERE " + prop.Name + " = " + valueOf + "";
                        }
                        else
                        {
                            Where += " AND " + prop.Name + " = " + valueOf + "";
                        }
                    }
                }
                else if (typeProp.Equals("System.String"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
            }
            Select += " FROM " + Object.Name + Where;
            return Select;
        }

        #endregion

        #region Update

        public string Update<T>(T entity)
        {
            String Update = "";
            String Where = "";
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;


            foreach (PropertyInfo prop in props)
            {
                if (String.IsNullOrEmpty(Update))
                {
                    Update = "Update " + Object.Name + " SET " + prop.Name + " ";
                }
                else
                {
                    //Select += " ," + prop.Name + " ";
                }


                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (typeProp.Contains("Int"))
                {
                    if (Convert.ToInt64(valueOf) > 0)
                    {
                        if (String.IsNullOrEmpty(Where))
                        {
                            Where = " WHERE " + prop.Name + " = " + valueOf + "";
                        }
                        else
                        {
                            Where += " AND " + prop.Name + " = " + valueOf + "";
                        }
                    }
                }
                else if (typeProp.Equals("System.String"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }

                    


                //Pego o valor da propriedade.
                // ValorDaPropriedade = propriedade.GetValue(entity, null);
                //string typeProp = propriedade.ToString().Replace(" " + propriedade.Name, "");


            }
            Select += " FROM " + Object.Name + Where;



            return Select;
        }

        #endregion


        #region Variable Type

        private string FormatV(string type, object variable)
        {
            if (type.Contains("Int"))
            {
                return "";
            }
            else if (type.Contains("System.String"))
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        #endregion
    }
}
