

//---------------------------------databases app---------------------------------//


using System;
using System.IO;

//namespace
namespace section_4
{
    //classes
    class Program
    {
        static void Main(string[] args)
        {

            //function:
            void asklogin(string info, string user, string pass){

                Console.WriteLine("Would you like to leave the site or continue?\n");
                string answer = Console.ReadLine();

                if(answer == "leave"){
                    Console.WriteLine("\nBefore you leave, all user data is stored inside a text file.\nThis file can be sold to scammers for money!");
                    Console.ReadLine();
                    Console.WriteLine("BYE!\n");
                }
                else if(answer == "continue"){
                    login(info, user, pass);
                }
                else{
                    Console.WriteLine("\nThis option is not yet available!\n");
                    asklogin(info, user, pass);
                }

            }

            void login(string info, string user, string pass){

                //mode
                Console.WriteLine("\nWould you like to view or edit your info, {0}\n", user);
                string mode = Console.ReadLine();

                //view
                if(mode == "view"){

                    Console.WriteLine("\nIn this section all of you info is stored.\nYour posts, freinds, comments, personal data, web history... are all stored here.\nAltough it is not rendered like facebook!");
                    Console.ReadLine();

                    Console.WriteLine($"Here is the info you stored:\n\n{info}\n");
                    asklogin(info, user, pass);
                }

                //edit
                else if(mode == "edit"){
                    
                    Console.WriteLine("\nWhen you make a post or add a freind, this info is automatically updated!");
                    Console.ReadLine();

                    Console.WriteLine($"Here is your old info:\n\n{info}\nWhat do you want your new info to be!\n");
                    string edit = Console.ReadLine();
                    string final = $"{user}*{pass}";             
                    int line_number = 0;

                    string[] lines = File.ReadAllLines(@"info.txt");
                    bool not_run = true;                    

                    try{

                        foreach (string line in lines){
                            
                            if(line.Contains(final) && not_run){
                                lines[line_number] = $"{user}*{pass}*{edit}";
                                File.WriteAllLines(@"info.txt", lines);
                                not_run = false;
                                asklogin(edit, user, pass);
                           }

                           line_number++;

                        } 

                    }catch{

                        Console.WriteLine($"{lines}");

                    }
                }else{

                    Console.WriteLine("\nSorry this mode is not available.");

                }
            }

            //variables:
            string username;
            string password;
            string information;
            string Account;
            string final;
            string e_username;
            string e_password;
            string[] lines2;
            int logged_in = 0;

            //intro
            Console.Clear();
            Console.WriteLine("Welcome to this application!\nThis app is like facebook exept that it deosn't render the information!\nI will be explaning the rest within the app!");
            Console.ReadLine();

            Console.WriteLine("Would you like to login or make an account?\n");
            Account = Console.ReadLine();

            //account
            if(Account.ToLower() == "make an account"){

                Console.WriteLine("In this section you can make an account!");
                Console.ReadLine();

                Console.WriteLine("\nGreat news. We just need some more info!");

                Console.WriteLine("\nUsername:");
                username = Console.ReadLine();
                Console.WriteLine("\nPassword:");
                password = Console.ReadLine();

                Console.WriteLine("\nHere facebook asks you about you interest, personal info, and freinds.\nIts all stored as I will show you soon!");
                Console.ReadLine();

                Console.WriteLine("\nInformation to store:");
                string info = Console.ReadLine();

                final = $"{username}*{password}*{info}\n";

                File.AppendAllText("info.txt", final);

                Console.WriteLine("\nYou have been automaticly logged in!");

                login(info, username, password);
            }

            
            if(Account == "login"){
                Console.WriteLine("\nSo in this phase you are logging in, on some devices this login happen automaticly.\nThis is shown when you make an account!");

                Console.WriteLine("Please enter your existing Username!\n\nUsername:");
                e_username = Console.ReadLine();

                Console.WriteLine("Please enter your existing Password!\n\nPassword:");
                e_password = Console.ReadLine();

                lines2 = System.IO.File.ReadAllLines(@"info.txt");

                foreach (string line in lines2)
                {
                    string [] info = line.Split("*");
                    username = info[0];
                    password = info[1];
                    information = info[2];

                    if(e_username == username && e_password == password){

                        Console.WriteLine("\nGreat news you have logged in!");
                        logged_in = 1;
                        login(information, e_username, e_password);
                        break;
                    }

                }
                if(logged_in == 0){
                    //error
                    Console.WriteLine("\nSorry some of the credentials were wrong please try again later!\n");
                }

            }

        }

    }

}
