namespace LOD_hometask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = args[0];
            string fileDirectory = args[1];
 
            string[] fileWithProfiles = getFile(fileDirectory);
 
            switch (command)
            {
                case "count":
                    Outputs.output(blankCounter(fileWithProfiles));
                    break;
                case "inDorm":
                    Outputs.output(liveInDorm(fileWithProfiles));
                    break;
                case "statistics":
                    Outputs.output(courseStatistics(fileWithProfiles));
                    break;
            }
            Console.ReadKey();
        }
 
        static string[] getFile(string fileDirectory)
        {
           return File.ReadAllLines(fileDirectory).Skip(1).ToArray();
        }
 
        static int blankCounter(string[] fileWithBlanks)
        {
            return fileWithBlanks.Length;
        }
 
        static List<string> liveInDorm(string[] fileWithBlanks)
        {
            List<string> inDormPersons = new List<string>();
            foreach(string currentString in fileWithBlanks)
            {
                var separatedLine = currentString.Split(';');
                if (separatedLine[4] == "Да")
                {
                    inDormPersons.Add(separatedLine[1]);
                }
            }
            return inDormPersons;
        }
        static int[] courseStatistics(string[] fileWithBlanks)
        {
            int[] counterArray = new int[4];
            foreach(string currentString in fileWithBlanks)
            {
                var separatedLine = currentString.Split(';');
                switch (separatedLine[2][0])
                {
                    case '1':
                        counterArray[0]++;
                        break;
                    case '2':
                        counterArray[1]++;
                        break;
                    case '3':
                        counterArray[2]++;
                        break;
                    case '4':
                        counterArray[3]++;
                        break;
                }
            }
            return counterArray;
        }
    }
}