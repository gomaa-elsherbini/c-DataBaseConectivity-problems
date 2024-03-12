using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Data.Common;



internal class Program
{
    static string connectionString = "Server=.; Database=ContactsDB; User Id=sa; Password=sa123456;";
    static void PrintAllContacts()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        
        string query = "SELECT * FROM Contacts";

        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"\nID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"CountryID: {countryID}\n");
                
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    static void PrintAllContactsWithFristName(string FirstName)
    {
        SqlConnection connection = new SqlConnection (connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName = @FirstName";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@FirstName", FirstName);

        try
        {
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"ID {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
            }
            reader.Close ();
            connection.Close();
        }
        catch(Exception ex) { Console.WriteLine( "Error: " + ex.Message ); }


    }
    static void PrintAllContactsWithFristNameAndID(string FirstName, int ID)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName = @FirstName AND ContactID=@ID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@ID", ID);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"ID {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }
    static void PrintAllContactsStartsWith(string like)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName LIKE '' + @like + '%'";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@like", like);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"ID {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }


    }
    static void PrintAllContactsEndstWith(string like)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%'+ @like + '' ";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@like", like);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"ID {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }


    }
    static void PrintAllContactsContains(string like)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%'+ @like +'%'";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@like", like);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"ID {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }


    }
    static string GetFirstColumnWithID(int contactID)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT FirstName FROM Contacts WHERE ContactID= @contactID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@contactID", contactID);

        string firstName = "";
        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null)
                firstName =  result.ToString();
            else
                firstName = "not found";

            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        
        return firstName;
    }
    public struct stContact
    {
        public int contactID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email{ get; set; }
        public string phone { get; set; }
        public string address{ get; set; }
        public int countryID{ get; set; }
    }
    static bool FindContactByID(int contactID, ref stContact contact)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "SELECT * FROM Contacts WHERE ContactID= @contactID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@contactID", contactID);
        
        bool isFound= false;

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                contact.contactID = (int)reader["ContactID"];
                contact.firstName = (string)reader["FirstName"];
                contact.lastName  = (string)reader["LastName"];
                contact.email = (string)reader["Email"];
                contact.phone = (string)reader["Phone"];
                contact.countryID = (int)reader["CountryID"];

                isFound = true;
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        
        return isFound;
    }
    static bool AddNewContact(stContact contact)
    {
        bool isAdded = false;

        SqlConnection connection = new SqlConnection(connectionString);
        string query = "INSERT INTO contacts(FirstName, LastName, Email, Phone, Address, CountryID) VALUES (@firstName, @lastName, @email, @phone, @address, @countryID); SELECT SCOPE_IDENTITY()";
        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@firstName", contact.firstName);
        command.Parameters.AddWithValue("@lastName", contact.lastName);
        command.Parameters.AddWithValue("@email", contact.email);
        command.Parameters.AddWithValue("@phone", contact.phone); 
        command.Parameters.AddWithValue("@address", contact.address); 
        command.Parameters.AddWithValue("@countryID", contact.countryID);

        try
        {
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            
            if(rowAffected > 0)
              Console.WriteLine("Contact Added Succesfully");
            else
                Console.WriteLine("Contact is not Added");

            isAdded = true;
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

        return isAdded;
    }
    static bool AddNewContactWithReturnIdentity(stContact contact)
    {
        bool isAdded = false;

        SqlConnection connection = new SqlConnection(connectionString);
        string query = "INSERT INTO contacts(FirstName, LastName, Email, Phone, Address, CountryID) VALUES (@firstName, @lastName, @email, @phone, @address, @countryID); SELECT SCOPE_IDENTITY()";
        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@firstName", contact.firstName);
        command.Parameters.AddWithValue("@lastName", contact.lastName);
        command.Parameters.AddWithValue("@email", contact.email);
        command.Parameters.AddWithValue("@phone", contact.phone);
        command.Parameters.AddWithValue("@address", contact.address);
        command.Parameters.AddWithValue("@countryID", contact.countryID);

        try
        {
            connection.Open();
            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int insertedID))
                Console.WriteLine($"Contact Added Succesfully and the newly inserted id: {insertedID}");
            else
                Console.WriteLine("Failde to retrive the inserrted id");

            isAdded = true;
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

        return isAdded;
    }
    static bool UpdateContactFirstName(int contactID, string firstName)
    {
        bool isUpdated = false;

        SqlConnection connection = new SqlConnection(connectionString);
        string query = "UPDATE contacts SET FirstName = @firstName WHERE ContactID = @contactID";
        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@contactID", contactID);
        command.Parameters.AddWithValue("@firstName", firstName);

        try
        {
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();

            if (rowAffected > 0)
                Console.WriteLine("Contact Updated Succesfully");
            else
                Console.WriteLine("Failde to Update Contact");

            isUpdated = true;
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

        return isUpdated;
    }
    static bool UpdateContact(int contactID, stContact contactInfo)
    {
        bool isUpdated = false;

        SqlConnection connection = new SqlConnection(connectionString);
        string query = @"UPDATE contacts 
                        SET FirstName = @firstName,
                            LastName = @lastName,
                            Email = @email,
                            Phone = @phone,
                            Address = @address,
                            CountryID = @countryID
                        WHERE ContactID = @contactID";
        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@firstName", contactInfo.firstName);
        command.Parameters.AddWithValue("@lastName", contactInfo.lastName);
        command.Parameters.AddWithValue("@email", contactInfo.email);
        command.Parameters.AddWithValue("@phone", contactInfo.phone);
        command.Parameters.AddWithValue("@address", contactInfo.address);
        command.Parameters.AddWithValue("@countryID", contactInfo.countryID);
        command.Parameters.AddWithValue("@contactID", contactID);

        try
        {
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();

            if (rowAffected > 0)
                Console.WriteLine("Contact Updated Succesfully");
            else
                Console.WriteLine("Failde to Update Contact");

            isUpdated = true;
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

        return isUpdated;
    }
    static bool DeleteContact(int contactID)
    {
        bool isDeleted = false;
        SqlConnection connection = new SqlConnection(connectionString);
        string query = @"DELETE FROM Contacts
                        WHERE ContactID = @contactID";
        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@contactID", contactID);

        try
        {
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();

            if (rowAffected > 0)
                Console.WriteLine("Contact Deleted Succesfully");
            else
                Console.WriteLine("Failde to Delete Contact");

            isDeleted = true;
            connection.Close();
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

        return isDeleted;
    }
    static void DeleteContactsWithIDRagne(string contactIDRanage)
    {
        SqlConnection connection = new SqlConnection(connectionString);

            string query = @"DELETE FROM Contacts
                            WHERE ContactID IN ("+contactIDRanage+");";
                
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                    Console.WriteLine("Contact Deleted Succesfully");
                else
                    Console.WriteLine("Failde to Delete Contact");

                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void Main(string[] args)
    {
        DeleteContactsWithIDRagne("5,18");

        Console.ReadKey();
    }
}

        /*
         DeleteContact(23);*/
        /*
        //UpdateContactFirstName(21, "programmingAdvices");

        stContact contact = new stContact();
        contact.firstName = "Khalil";
        contact.lastName = "Anani";
        contact.email = "kh@gmail.com";
        contact.phone = "0121654564654";
        contact.address = "10 st cairo egypt";
        contact.countryID = 2;

        UpdateContact(21, contact);
         */
        /*
        stContact contact = new stContact();
        contact.firstName = "Mohammad";
        contact.lastName = "Abou-Hadhuod";
        contact.email = "m@gmail.com";
        contact.phone = "0121654564654";
        contact.address = "10 st cairo egypt";
        contact.countryID = 2;

        //AddNewContact(contact);
        AddNewContactWithReturnIdentity(contact);
         */
        /*
        stContact contact = new stContact();

        if (FindContactByID(1, ref contact))
        {
            Console.WriteLine($"\nID: {contact.contactID}");
            Console.WriteLine($"Name:  {contact.firstName} {contact.lastName}");
            Console.WriteLine($"Email: {contact.email}");
            Console.WriteLine($"Phone: {contact.phone}");
            Console.WriteLine($"CountryID: {contact.countryID}\n");
        }
        else
            Console.WriteLine("contact not found!");
        */
        /*
        //PrintAllContacts();
        //PrintAllContactsWithFristName("jane");
        //PrintAllContactsWithFristNameAndID("jane", 17);
        //PrintAllContactsStartsWith("j");
        //PrintAllContactsEndstWith("ar");
        //PrintAllContactsContains("ma");
        //GetFirstColumnWithID(1);
        //Console.WriteLine($"Name: {GetFirstColumnWithID(1)}");   
        */