using System.Diagnostics;

namespace ConsoleApp1{
    internal class Program{

        // Task 1
        static void ShowProcesses() {

            while (true) {
                Console.Clear();

                int Proces_counter = 0;


                var processes = Process.GetProcesses();
                var proces_List = processes.Where(p =>{
                    try {
                        var time = p.StartTime;
                        return true;
                    }
                    catch {
                        return false;
                    }
                }).OrderByDescending(p => p.StartTime).Take(20);

                foreach (var p in proces_List) {
                    Proces_counter++;
                    Thread.Sleep(500);
                    Console.WriteLine($"Process Number: {Proces_counter}");
                    Console.WriteLine($"Id: {p.Id}");
                    Console.WriteLine($"Name: {p.ProcessName}");
                    Console.WriteLine($"Start: {p.StartTime}");
                    Console.WriteLine();
                }
            }
        }

        static void KillOrStartProcess() {
            int choice;
            while (true) {
                Thread.Sleep(1000);
                Console.WriteLine("Processes For Controlling");
                Console.Write("Pick With Number !!!:\n1-Chrome\n2-Notepad\n3-Calculator\n4-Paint\n5-Exit\nChoose:");
                Console.WriteLine("\n");
                choice = Convert.ToInt32(Console.ReadLine());

                var processes_List = Process.GetProcesses();
                if (choice == 1) {
                    bool chromeFound = false;

                    foreach (var item in processes_List) {
                        if (item.ProcessName.Contains("chrome")) {
                            item.Kill();
                            chromeFound = true;
                            break;
                        }
                    }

                    if (chromeFound == false) {
                        Process.Start(@"C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe");
                    }
                }

                if (choice == 2) {
                    bool notepadFound = false;

                    foreach (var item in processes_List) {
                        if (item.ProcessName.Contains("Notepad")) {
                            item.Kill();
                            notepadFound = true;
                            break;
                        }
                    }

                    if (notepadFound == false) {
                        Process.Start(@"notepad.exe");
                    }
                }

                if (choice == 3) {
                    bool calculatorFound = false;

                    foreach (var item in processes_List) {
                        if (item.ProcessName.Contains("CalculatorApp")) {
                            item.Kill();
                            calculatorFound = true;
                            break;
                        }
                    }

                    if (calculatorFound == false) {
                        Process.Start(@"C:\Windows\System32\calc.exe");
                    }
                }

                if (choice == 4) {
                    bool paintFound = false;

                    foreach (var item in processes_List) {
                        if (item.ProcessName.Contains("paint")) {
                            item.Kill();
                            paintFound = true;
                            break;
                        }
                    }

                    if (paintFound == false) {
                        Process.Start("mspaint.exe");
                    }
                }
                if (choice == 5) {
                    break;
                }
            }
        }
        static void Main(string[] args){
            var pTh1 = new Thread(ShowProcesses);
            pTh1.Start();

            var pTh2 = new Thread(KillOrStartProcess);
            pTh2.Start();
        }
    }
}
