// See https://aka.ms/new-console-template for more information
using Microshaoft;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

var assemblyName = Assembly
                        .GetExecutingAssembly()
                        .GetName()
                        .Name;
var secret = "AwesomeYuer.Microshaoft.com";

if (args == null || args.Length < 1)
{
    Help();
    return;
}
string certificateFileName = String.Empty;
using
    (
        var x509Store = new X509Store
                                (
                                    StoreName.My
                                    , StoreLocation.CurrentUser
                                //, OpenFlags.ReadWrite
                                )
    )
{
    if
        (
            string.Compare(args[0], "--add", true) == 0
            ||
            string.Compare(args[0], "-a", true) == 0
        )
    {
        certificateFileName = args[1];

        if (!File.Exists(certificateFileName))
        {
            ConsoleHelper
                    .HighlightWriteLine
                            (@$"Error: Certificate File ""{certificateFileName}"" is not found!");
            Help();
            return;
        }

        var subjectName = string.Empty;

        void Add()
        {
            try
            {
                if (x509Store.IsOpen)
                {
                    x509Store.Close();
                }
                x509Store
                        .Open(OpenFlags.ReadWrite);
                var x509Certificate2 = new X509Certificate2
                                        (
                                            certificateFileName
                                        //, ""
                                        //,
                                        //    X509KeyStorageFlags.Exportable
                                        //    |
                                        //    X509KeyStorageFlags.PersistKeySet
                                        );
                subjectName = x509Certificate2
                                        .SubjectName
                                        .Name;

                x509Store
                        .Add
                            (
                                x509Certificate2
                            );
            }
            finally
            {
                if (x509Store.IsOpen)
                {
                    x509Store.Close();
                }
            }
        }

        var x509Certificate2 = x509Store
                                    .GetCertificate(subjectName);

        while (x509Certificate2 == null)
        {
            Add();
            x509Certificate2 = x509Store
                                    .GetCertificate(subjectName);
        }

        ConsoleHelper
                .HighlightWriteLine
                        (
                            $"Info: Added and Found X509Certificate2 {nameof(x509Certificate2.SubjectName)}: [{x509Certificate2.SubjectName.Name}] @ [{x509Store.Name}] @ [{x509Store.Location}] successfully!"
                            , ConsoleColor.Green
                        );
    }
    else if
        (
            string.Compare(args[0], "--remove", true) == 0
            ||
            string.Compare(args[0], "-r", true) == 0
        )
    {
        var subjectName = args[1];

        Remove();
        void Remove()
        {
            if (!subjectName.StartsWith("CN="))
            {
                subjectName = $"CN={subjectName}";
            }
            var x509Certificate2 = x509Store
                                        .GetCertificate(subjectName);
            if (x509Certificate2 != null)
            {
                try
                {
                    if (x509Store.IsOpen)
                    {
                        x509Store.Close();
                    }
                    x509Store
                            .Open(OpenFlags.ReadWrite);
                    x509Store
                            .Remove
                                (
                                    x509Certificate2
                                );
                }
                finally
                {
                    if (x509Store.IsOpen)
                    {
                        x509Store.Close();
                    }
                }
            }
            ConsoleHelper
                    .HighlightWriteLine
                            (
                                $"Info: Removed X509Certificate2 {nameof(subjectName)}: [{subjectName}] @ [{x509Store.Name}] @ [{x509Store.Location}] successfully!"
                                , ConsoleColor.Green
                            );
        }
    }
    else
    {
        ConsoleHelper
                .HighlightWriteLine
                        ("Error: Wrong Usage.");
        Console.WriteLine();
        Help();
    }
}

void Help()
{
    Console.WriteLine("help Samples:");

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        Console.WriteLine("Add:");
        Console.WriteLine($"\t{assemblyName} --add \".\\{nameof(certificateFileName)}\"");
        Console.WriteLine($"\t{assemblyName} -a \".\\{nameof(certificateFileName)}\"");
        Console.WriteLine();
        Console.WriteLine("Remove:");
        Console.WriteLine($"\t{assemblyName} --remove \"{secret}\"");
        Console.WriteLine($"\t{assemblyName} -r \"{secret}\"");
    }
    else
    {
        Console.WriteLine("Add:");
        Console.WriteLine($"\tdotnet {assemblyName}.dll --add \"./{nameof(certificateFileName)}\"");
        Console.WriteLine($"\tdotnet {assemblyName}.dll -a \"./{nameof(certificateFileName)}\"");
        Console.WriteLine();
        Console.WriteLine("Remove:");
        Console.WriteLine($"\tdotnet {assemblyName}.dll --remove \"{secret}\"");
        Console.WriteLine($"\tdotnet {assemblyName}.dll -r \"{secret}\"");
    }
    Console.WriteLine();
    Console.WriteLine("Copyright (c) AwesomeYuer@Microshaoft.com.");

}
