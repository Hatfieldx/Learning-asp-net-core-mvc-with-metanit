using System;


namespace ConfigEdu
{
    public class Order
    {
        public int ID { get; set; }
        public string magazin_id { get; set; }
        public Kontragent kontragent { get; set; }
    }

    public class Kontragent
    {
        public string id { get; set; }
        public string full_name { get; set; }
        public int face_type { get; set; }
        public Contact contact { get; set; }
        public int group_id { get; set; }
        public Guid? UIDContractor { get; set; }
    }

    public class Contact
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
