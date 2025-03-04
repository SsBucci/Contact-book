public class Contact : IComparable<Contact>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, string phoneNumber, string email)
    {
        if (name == null)
            throw new System.ArgumentNullException(nameof(name));
        if (phoneNumber == null)
            throw new System.ArgumentNullException(nameof(phoneNumber));
        if (email == null)
            throw new System.ArgumentNullException(nameof(email));

        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public int CompareTo(Contact other)
    {
        if (other == null)
            return 1;

        return CompareStrings(Name, other.Name);
    }

    private int CompareStrings(string str1, string str2)
    {
        int len1 = str1.Length;
        int len2 = str2.Length;

        for (int i = 0; i < len1 && i < len2; i++)
        {
            if (str1[i] != str2[i])
                return str1[i] - str2[i];
        }

        return len1 - len2;
    }

    
    public override string ToString()
    {
        return Name + ", " + PhoneNumber + ", " + Email;
    }
}

