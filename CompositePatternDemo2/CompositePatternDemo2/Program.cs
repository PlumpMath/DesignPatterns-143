using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternDemo2
{
    interface IFIleSystemElement
    {
        void Add(IFIleSystemElement element);
        void Remove(IFIleSystemElement element);
        void Display();

        string  Name { get; }

    }

    class File: IFIleSystemElement
    {
        private string fileName;
        public File(string name)
        {
            fileName = name;
        }
        public void Add(IFIleSystemElement element)
        {
            Console.WriteLine("Cannot add");
        }

        public void Remove(IFIleSystemElement element)
        {
            Console.WriteLine("Cannot remove");
        }

        public void Display()
        {
            Console.WriteLine(Name);
        }

        public string Name
        {
            get { return fileName; }
        }
    }

    class Folder : IFIleSystemElement
    {
        private List<IFIleSystemElement> children = new List<IFIleSystemElement>();
        private string folderName;

        public Folder(string name)
        {
            folderName = name;
        }
        public void Add(IFIleSystemElement element)
        {
            children.Add(element);
        }

        public void Remove(IFIleSystemElement element)
        {
            children.Remove(element);
        }

        public void Display()
        {
            Console.WriteLine(Name);
            foreach (var childElement in children)
            {
                childElement.Display();
            }
            ;
        }

        public string Name { get { return folderName; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Folder root = new Folder("root");
            root.Add(new File("FIle 1"));
            root.Add(new File("FIle 2"));
            root.Add(new File("FIle 3"));
            root.Add(new File("FIle 4"));
            var subFolder = new Folder("subFolder");
            root.Add(subFolder);
            subFolder.Add(new File("SubFolder File 1"));
            subFolder.Add(new File("SubFolder File 2"));
            subFolder.Add(new File("SubFolder File 3"));
            subFolder.Add(new File("SubFolder File 4"));
            root.Display();
            Console.ReadKey();
        }
    }
}
