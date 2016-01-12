namespace MyBrowser.Model
{
    class Site
    {
        public string Order { get; set; }

        public string Address { get; set; }

        public string DisplayName
        {
            get
            {
                return Order + " - " + Address;                
            }
        }
    }
}
