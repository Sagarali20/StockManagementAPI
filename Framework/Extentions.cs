using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SERP.Framework
{
    public static class Extentions
    {
        #region Date Format
        public static string DateFormat(this DateTime? date)
        {
            if(!date.HasValue || date.Value == new DateTime())
            {
                return "";
            }
            return GetDateFormat(date.Value);
        }
        public static string DateFormat(this DateTime date)
        {
            return GetDateFormat(date);
        }
        public static string DateFormat(this DateTime? date,string format)
        {
            if (!date.HasValue || date.Value == new DateTime())
            {
                return "";
            }
            if (!string.IsNullOrWhiteSpace(format))
            {
                string dateVal = GetDateFormat(date.Value);
                string formatVal = dateVal.Split('/')[2];
                if (format=="day")
                {
                    formatVal = dateVal.Split('/')[1];
                    string suffix = "th";
                    if (int.Parse(formatVal) == 1 || int.Parse(formatVal) % 20 == 1 || int.Parse(formatVal) % 30 == 1)
                    {
                        suffix = "st";
                    }
                    else if (int.Parse(formatVal) == 2 || int.Parse(formatVal) % 20 == 2)
                    {
                        suffix = "nd";
                    }
                    else if (int.Parse(formatVal) == 3 || int.Parse(formatVal) % 20 == 3)
                    {
                        suffix = "rd";
                    }
                    return formatVal + suffix;
                }
                else if(format=="month")
                {
                    formatVal = dateVal.Split('/')[0];
                }
                else if (format == "monthName")
                {
                    formatVal = date.Value.ToString("MMMM");
                }
                return formatVal;
            }
            return GetDateFormat(date.Value);
        }
        public static string DateFormat(this DateTime date, string format)
        {
            if (!string.IsNullOrWhiteSpace(format))
            {
                string dateVal = GetDateFormat(date);
                string formatVal = dateVal.Split('/')[2];
                if (format == "day")
                {
                    formatVal = dateVal.Split('/')[1];
                    string suffix = "th";
                    if (int.Parse(formatVal) == 1 || int.Parse(formatVal) % 20 == 1 || int.Parse(formatVal) % 30 == 1)
                    {
                        suffix = "st";
                    }
                    else if (int.Parse(formatVal) == 2 || int.Parse(formatVal) % 20 == 2)
                    {
                        suffix = "nd";
                    }
                    else if (int.Parse(formatVal) == 3 || int.Parse(formatVal) % 20 == 3)
                    {
                        suffix = "rd";
                    }
                    return formatVal + suffix;
                }
                else if (format == "month")
                {
                    formatVal = dateVal.Split('/')[0];
                }
                else if (format == "monthName")
                {
                    formatVal = date.ToString("MMMM");
                }
                return formatVal;
            }
            return GetDateFormat(date);
        }
        private static string GetDateFormat(DateTime date)
        {
            string FormatDate = "";
            if (date != null && date != new DateTime())
            {
                string monthFormat = "MM";
                string dayFormat = "dd";
                if (date.Day < 10)
                {
                    dayFormat = "d";
                }
                if (date.Month < 10)
                {
                    monthFormat = "M";
                }

                FormatDate = date.ToString(string.Format("{0}/{1}/yy", monthFormat, dayFormat));
            }
            return FormatDate;
        }

        public static string RugDateFormat(DateTime date)
        {
            if (date != null)
            {
                var month = date.ToString("MMM");
                int day = int.Parse(date.ToString("dd"));
                var year_time = date.ToString("yyyy h:mm tt");
                string suffix = "th";
                if (day == 1 || day == 21 || day == 31)
                {
                    suffix = "st";
                }
                else if (day == 2 || day == 22)
                {
                    suffix = "nd";
                }
                else if (day == 3 || day == 23)
                {
                    suffix = "rd";
                }
                return month + " " + day + suffix + ", " + year_time;
                //output: Aug 19th, 2020 11:00 AM
            }
            else
            {
                return "";
            }
        }

        #endregion
        public static T FieldOrDefault<T>(this DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? default(T) : row.Field<T>(columnName);
        } 
        public static DataTable ListToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable("WorkSheet");
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.IsBrowsable)
                {
                    table.Columns.Add(string.IsNullOrWhiteSpace(prop.DisplayName) ? prop.Name : prop.DisplayName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow(); 
                foreach (PropertyDescriptor prop in properties)
                {
                    if (prop.IsBrowsable)
                    {
                        row[string.IsNullOrWhiteSpace(prop.DisplayName) ? prop.Name : prop.DisplayName] = prop.GetValue(item) ?? DBNull.Value;
                    }
                }
                table.Rows.Add(row); 
            }
            return table;
        }
        public static double MinutesToDecimalHours(this int TotalMunites)
        {
            int Hour = TotalMunites / 60;
            double Munites = TotalMunites % 60;
            Munites = Munites * 0.01666667;
            return Math.Round(Hour + Munites, 2);

        }
        public static double SecondToDecimalHours(this int TotalMunites)
        {
            int Hour = TotalMunites / 3600;
            double Munites = TotalMunites % 3600;
            Munites = Munites * 0.01666667;
            return Math.Round(Hour + Munites, 2);

        }
        public static string toFixed(this double number, uint decimals)
        {
            return number.ToString("N" + decimals);
        }
        #region Phone Number Format
        public static string PhoneNumberFormat(this string Number)
        {
            if (!string.IsNullOrWhiteSpace(Number))
            {
                Number = Number.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ","");
                if (Number.Length == 10)
                {
                    var sb = new StringBuilder(Number);
                    sb.Insert(3, "-");
                    sb.Insert(7, "-");
                    return sb.ToString();
                }
            }
            return Number;
        }
        //private static string AppendAtPosition(string baseString, int position, string character)
        //{
        //    var sb = new StringBuilder(baseString);
        //    for (int i = position; i < sb.Length; i += (position + character.Length))
        //        sb.Insert(i, character);
        //    return sb.ToString();
        //}
        #endregion

        public static DateTime ToDateTime(this string StrDateTime)
        {
            /*
             SUPPORTED FORMAT
            //YYYY-MM-DD
            //MM/DD/YYYY
            //MM/DD/YYYY HH:MM:SS TT
            */
            DateTime Date = new DateTime();

            if(!string.IsNullOrWhiteSpace(StrDateTime) && StrDateTime.Split('-').Count() == 3)
            {
                int Year ;
                int Month ;
                int Day ;
                var Datevalues = StrDateTime.Trim().Split('-');
                if (int.TryParse(Datevalues[1], out Month) && Month > 0 && Month < 13
                       && int.TryParse(Datevalues[2], out Day) && Day > 0 && Day < 32
                       && int.TryParse(Datevalues[0], out Year) && Year > 1910)
                {
                    Date = new DateTime(Year, Month, Day);
                }
                return Date;
            }

            if (!string.IsNullOrWhiteSpace(StrDateTime))
            {
                StrDateTime = StrDateTime.Trim();
                string StrDate = "";
                string StrTime = "";
                string AMPM = "";
                bool IsPM = false;

                if (StrDateTime.IndexOf(" ") > 8 && StrDateTime.Split(' ').Count()==2)
                {
                    StrDate = StrDateTime.Split(' ')[0];
                    StrTime = StrDateTime.Split(' ')[1];
                }
                else if (StrDateTime.IndexOf(" ") > 8 && StrDateTime.Split(' ').Count() == 3)
                {
                    StrDate = StrDateTime.Split(' ')[0];
                    StrTime = StrDateTime.Split(' ')[1];
                    AMPM= StrDateTime.Split(' ')[2];
                    IsPM = AMPM.ToLower() == "pm"; 
                }
                else
                {
                    StrDate = StrDateTime;
                }

                #region Date
                var Datevalues = StrDate.Trim().Split('/');
                if (Datevalues.Length == 3)
                {
                    int Day = 0;
                    int Month = 0;
                    int Year = 0;
                    if (int.TryParse(Datevalues[0], out Month) && Month > 0 && Month < 13
                        && int.TryParse(Datevalues[1], out Day) && Day > 0 && Day < 32
                        && int.TryParse(Datevalues[2], out Year) && Year > 1910)
                    {
                        Date = new DateTime(Year, Month, Day);
                    }
                }
                #endregion

                #region Time
                if(Date != new DateTime() && !string.IsNullOrWhiteSpace(StrTime))
                {
                    
                    
                    //if(StrTime.IndexOf(" ") > 2)
                    //{
                    //    StrTime = StrTime.Split(' ')[0];
                    //    IsPM = StrTime.Split(' ')[1].ToLower() == "pm";
                    //}

                    var Timevalues = StrTime.Trim().Split(':');
                    #region AddTime
                    if(Timevalues.Length > 1 && Timevalues.Length < 4)
                    {
                        int Hour = 0;
                        int Munite = 0;
                        int Second = 0;

                        if (int.TryParse(Timevalues[0], out Hour) && Hour > -1 && Hour < 24)
                        {
                            if (IsPM && Hour < 13)
                                Hour += 12;

                            Date = Date.AddHours(Hour);
                        }
                        if (int.TryParse( Timevalues[1], out Munite) && Munite > -1 && Munite < 60)
                        {
                            Date = Date.AddMinutes(Munite);
                        }
                        if (Timevalues.Length > 2 && int.TryParse(Timevalues[2], out Second) && Second > -1 && Second < 60)
                        {
                            Date = Date.AddSeconds(Second);
                        }
                    }
                    #endregion
                }
                #endregion
            }
            return Date;
        }

        public static string GetCardType(this string cardNumber)
        {
            cardNumber = cardNumber.Replace("-","");
            //https://www.regular-expressions.info/creditcard.html
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return "Visa";
            }

            if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                return "MasterCard";
            }

            if (Regex.Match(cardNumber, @"^3[47][0-9]{13}$").Success)
            {
                return "AmericanExpress";
            }

            if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$").Success)
            {
                return "Discover";
            }

            if (Regex.Match(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$").Success)
            {
                return "JCB";
            }
            return "Others";
        }

        public static string ToDateTimeText(this DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return datetime.Value.ToString("MM/dd/yyyy hh:mm tt");
            }
            else
            {
                return "-";
            }
        }
        public static string ToDateText(this DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return datetime.Value.ToString("MM/dd/yyyy");
            }
            else
            {
                return "-";
            }
        }
        public static string GenerateBookingNo(this int BookingId)
        {
            string BookingFormat = "00000000";
            BookingFormat = string.Concat(BookingFormat, BookingId);
            BookingFormat = string.Format("BK{0}", BookingFormat.Substring(BookingFormat.Length - 8));
            return BookingFormat;
        }
        public static string GenerateInvoiceNo(this int InvoiceId)
        {
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat,InvoiceId);
            InvoiceFormat = string.Format("INV{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8));
            return InvoiceFormat;
        }

        public static string GenerateVehicleModelSKUNo(int modelid, string prefix)
        {
            string ModelFormat = "00000";
            ModelFormat = string.Concat(ModelFormat, modelid);
            ModelFormat = string.Format("{0}{1}{2}", prefix, ModelFormat.Substring(ModelFormat.Length - 5), "XXXXXX");
            return ModelFormat;
        }

        public static string GenerateVehicleModelSKUNoUpdate(int eqpid, string sku)
        {
            sku = !string.IsNullOrWhiteSpace(sku) ? sku.Replace("XXXXXX", "") : "";
            string ModelFormat = "000000";
            ModelFormat = string.Concat(ModelFormat, eqpid);
            ModelFormat = string.Format("{0}{1}", sku, ModelFormat.Substring(ModelFormat.Length - 6));
            return ModelFormat;
        }

        public static string GenerateServiceNo(this int InvoiceId)
        {
            string InitialFormat = "G" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "-";
            string InvoiceFormat = "000";
            InvoiceFormat = string.Concat(InvoiceFormat, InvoiceId);
            InvoiceFormat = string.Format("{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 3));
            InvoiceFormat = InitialFormat + InvoiceFormat;
            return InvoiceFormat;
        }
        public static string GeneratePackageNo(this int InvoiceId)
        {
            string InitialFormat = "P" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "-";
            string InvoiceFormat = "0000";
            InvoiceFormat = string.Concat(InvoiceFormat, InvoiceId);
            InvoiceFormat = string.Format("{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 4));
            InvoiceFormat = InitialFormat + InvoiceFormat;
            return InvoiceFormat;
        }
        public static string GenerateServiceNo2(this int InvoiceId)
        {
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat, InvoiceId);
            InvoiceFormat = string.Format("IVC{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8));
            return InvoiceFormat;
        }
        public static string GenerateInvoiceBatchNo(this string strDate)
        {
            string InvoiceFormat = "000000000000";
            InvoiceFormat = string.Concat(InvoiceFormat, strDate);
            InvoiceFormat = string.Format("BTH{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 12));
            return InvoiceFormat;
        }
        public static string GenerateEstimateNo(this int EstimateId)
        {
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat, EstimateId);
            InvoiceFormat = string.Format("EST{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8));
            return InvoiceFormat;
        }
        public static string GeneratePONo(this int EstimateId, string PreText)
        {
            if(string.IsNullOrWhiteSpace(PreText))
            {
                PreText = "PO";
            }
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat, EstimateId);
            InvoiceFormat = string.Format("{1}{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8),PreText);
            return InvoiceFormat;
        }
        public static string GenerateDONoBranch(this int EstimateId)
        {
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat, EstimateId);
            InvoiceFormat = string.Format("DOB{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8));
            return InvoiceFormat;
        }
        public static string GenerateDONoTech(this int EstimateId)
        {
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat, EstimateId);
            InvoiceFormat = string.Format("DOT{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8));
            return InvoiceFormat;
        }
        public static string GenerateBillNO(this int EstimateId)
        {
            string InvoiceFormat = "00000000";
            InvoiceFormat = string.Concat(InvoiceFormat, EstimateId);
            InvoiceFormat = string.Format("BL{0}", InvoiceFormat.Substring(InvoiceFormat.Length - 8));
            return InvoiceFormat;
        }
        public static string ToTimeText(this DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return datetime.Value.ToString("hh:mm tt");
            }
            else
            {
                return "-";
            }
        }
        public static bool IsValidEmailAddress(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static string[] Split(this string data,string SplitBy)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }
            return data.Split(new string[] { SplitBy }, StringSplitOptions.None);
        }
        public static string UppercaseFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            s = s.ToLower();
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public static string CapitalizeFirst(this string s)
        {
            bool IsNewSentense = true;
            var result = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(s[i]))
                {
                    result.Append(char.ToUpper(s[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append(s[i]);

                if (s[i] == ' ')
                {
                    IsNewSentense = true;
                }
            }

            return result.ToString();
        }
        public static DateTime SetZeroHour(this DateTime datetime)
        {
            return new DateTime(datetime.Year,datetime.Month,datetime.Day,0,0,0);
        }
        //public static DateTime SetClientZeroHourToUTC(this DateTime datetime)
        //{
        //    return new DateTime(datetime.Year, datetime.Month, datetime.Day, 0, 0, 0).ClientToUTCTime();
        //}
        public static DateTime SetMaxHour(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59);
        }
        //public static DateTime SetClientMaxHourToUTC(this DateTime datetime)
        //{
        //    return new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59).ClientToUTCTime();
        //}
        public static DateTime UTCCurrentTime(this DateTime datetime)
        {
            datetime = DateTime.UtcNow;
            return datetime;
        }
        public static string ReplaceSpecialChar(this string value,string newvalue="-")
        {
            if (value == null)
                return "";
            return Regex.Replace(value, @"[^0-9a-zA-Z]+", newvalue);
        }
        public static string ReplaceSpecialQuotation(this string value, string newvalue = "`")
        {
            if (value == null)
                return "";
            return Regex.Replace(value, @"'", newvalue);
        }
        public static string ReplaceSpecialCharFile(this string value, string newvalue = "_")
        {
            if (value == null)
                return "";
            value = value.Replace(" ","");
            return Regex.Replace(value, @"[^0-9a-zA-Z.]+", newvalue);
        }
        public static string ReplaceSpecialCharForPropertySearch(this string value, string newvalue = "-")
        {
            return Regex.Replace(value, @"[^0-9a-zA-Z()]+", newvalue);
        }
        public static string ReplaceWithMalyasia(this string value)
        {
            return Regex.Replace(value, "Malaysia", "");
        }
        public static string ReplaceSpecialCharWithSingleQuote(this string value, string newvalue = "-")
        {
            return Regex.Replace(value, @"'[^0-9a-zA-Z]+", newvalue);
        }
        public static string ToDateToListString(this DateTime? value)
        {
            return value.HasValue ? "Added On : " + value.Value.ToString("MMM dd") : string.Empty;
        }
        public static List<T> ConvertToList<T>(this DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();

            var properties = typeof(T).GetProperties();

            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();

                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name) && row[pro.Name] != DBNull.Value)
                        pro.SetValue(objT, row[pro.Name]);
                   
                }
                return objT;
            }).ToList();

        }
        public static List<T> GetListModel<T>(this DataTable dt)
        {
            List<T> lst = new List<T>();
            foreach (DataRow dw in dt.Rows)
            {
                Type Tp = typeof(T);
                //create instance of the type
                T obj = Activator.CreateInstance<T>();
                //fetch all properties
                PropertyInfo[] pf = Tp.GetProperties();
                foreach (PropertyInfo pinfo in pf)
                {
                    ///read the implimeted custome atribute for a property
                    object[] colname = pinfo.GetCustomAttributes(typeof(DataTableColName), false);
                    if (colname == null) continue;
                    if (colname.Length == 0) continue;
                    ///read column name from that atribute object
                    string col = (colname[0] as DataTableColName).CoulumnName;
                    if (!dt.Columns.Contains(col)) continue;
                    if (dw[col] == null) continue;
                    if (dw[col] == DBNull.Value) continue;
                    ///set property value
                    pinfo.SetValue(obj, dw[col], null);
                }
                lst.Add(obj);
            }
            return lst;
        }

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperties().Where(p => p.Name == prop.Name).SingleOrDefault(); 
                            //obj.GetType().GetProperty(prop.Name);
                            //propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            if (propertyInfo != null)
                            {
                                Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                                object safeValue = (row[prop.Name] == null) ? null : Convert.ChangeType(row[prop.Name], t);

                                propertyInfo.SetValue(obj, safeValue, null);
                            }
                        }
                        catch(Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<T> ToList<T>(this DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => ToModel<T>(row, columnsNames));

                return Temp;
            }
            catch { return Temp; }
        }

        public static T ToModel<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties; Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                } return obj;
            }
            catch { return obj; }
        }
        public static float ToFloat(this string value)
        {
            float result = 0;
            float.TryParse(value, out result);
            return result;
        }
        public static bool ToBool(this string value)
        {
            bool result = false;
            bool.TryParse(value, out result);
            return result;
        }
        public static int ToInt(this string value)
        {
            int result = 0;
            int.TryParse(value, out result);
            return result;
        }
        public static decimal ToDecimal(this string value)
        {
            decimal result = 0;
            decimal.TryParse(value, out result);
            return result;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
    public class DataTableColName : Attribute
    {
        string coulumnName = string.Empty;
        public string CoulumnName
        {
            get { return coulumnName; }
            set { coulumnName = value; }
        }
        public DataTableColName(string colName)
        {
            coulumnName = colName;
        }
    }
    
}
