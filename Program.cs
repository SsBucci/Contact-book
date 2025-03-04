using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        DynamicArray contacts = new DynamicArray();

        // Add some default contacts
        contacts.Add(new Contact("Evans", "0778905262", "emrasmaz@gmail.com"));
        contacts.Add(new Contact("Sunera", "0721925898", "nilwakka@gmail.com"));
        contacts.Add(new Contact("Imal", "0785632147", "adikariims@gmail.com"));

        // Display welcome screen
        ShowWelcomeScreen();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine(" Please choose the desired action to proceed...");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\n");


            Console.WriteLine("n - Add New Contact");
            Console.WriteLine("d - Delete Contact");
            Console.WriteLine("s - Sort Contacts");
            Console.WriteLine("v - View All Contacts");
            Console.WriteLine("f - Find Contact by Name");
            Console.WriteLine("q - Quit");
            Console.WriteLine("-------------------------------------");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "n":
                    AddContact(contacts);
                    break;
                case "d":
                    DeleteContact(contacts);
                    break;
                case "s":
                    SortContacts(contacts);
                    break;
                case "v":
                    ViewContacts(contacts);
                    break;
                case "f":
                    FindContact(contacts);
                    break;
                case "q":
                    running = false;
                    Console.WriteLine("\nThank you for using the Contact Book!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ShowWelcomeScreen()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("            CONTACT BOOK             ");
        Console.WriteLine("=====================================");
        Console.WriteLine("         Manage your contacts         ");
        Console.WriteLine("=====================================");
        Console.WriteLine("\n");
        Console.WriteLine("\n");
    }

    static void AddContact(DynamicArray contacts)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        contacts.Add(new Contact(name, phoneNumber, email));
        Console.WriteLine("\nContact added successfully!");
    }

    static void DeleteContact(DynamicArray contacts)
    {
        Console.Write("Enter index of contact to delete(1,2,3): ");
        int index = int.Parse(Console.ReadLine());
        contacts.Remove(index-1);
        Console.WriteLine("\nContact deleted successfully!");
    }

    static void SortContacts(DynamicArray contacts)
    {
        Console.WriteLine("Choose sorting method: 1 - Bubble Sort, 2 - Merge Sort");
        string choice = Console.ReadLine();

        
        DynamicArray tempContacts = new DynamicArray();
        for (int i = 0; i < contacts.Size(); i++)
        {
            tempContacts.Add(contacts.Get(i));
        }

        if (choice == "1")
        {
            
            tempContacts = Sorting.BubbleSort(tempContacts);
        }
        else if (choice == "2")
        {
           
            tempContacts = Sorting.MergeSort(tempContacts);
        }

        
        Console.WriteLine("\nSorted Contacts:");
        for (int i = 0; i < tempContacts.Size(); i++)
        {
            Contact contact = tempContacts.Get(i);
            Console.WriteLine($"Name        : {contact.Name}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Email       : {contact.Email}");
            Console.WriteLine("-------------------------------------");
        }
    }

    static void ViewContacts(DynamicArray contacts)
    {
        Console.WriteLine("\nContact List:");
        for (int i = 0; i < contacts.Size(); i++)
        {
            Contact contact = contacts.Get(i);
            Console.WriteLine($"\nContact {i + 1}:");
            Console.WriteLine($"Name        : {contact.Name}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Email       : {contact.Email}");
            Console.WriteLine("-------------------------------------");
        }
    }

    static void FindContact(DynamicArray contacts)
    {
        Console.Write("Enter Name to search: ");
        string name = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < contacts.Size(); i++)
        {
            Contact contact = contacts.Get(i);
            if (contact.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nContact Found:");
                Console.WriteLine($"Name        : {contact.Name}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email       : {contact.Email}");
                Console.WriteLine("-------------------------------------");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No contact found with that name.");
        }
    }

}

