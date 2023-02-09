using System.Security.Cryptography.X509Certificates;

namespace mda
{
    struct ZNAK
    {
        public NAME name;
        //public string name;
        public string zodiac;
        public int[] bdate;

        public ZNAK()
        {
            name.Name = "";
            name.Surname = "";
            zodiac = "";
            bdate = new int[3] ;
        }


    }

    struct NAME
    {
        public string Name;
        public string Surname;
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}