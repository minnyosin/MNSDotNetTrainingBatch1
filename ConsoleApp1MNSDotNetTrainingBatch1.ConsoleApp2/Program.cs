using System.Data;
using System.Data.Common;
using ConsoleApp1MNSDotNetTrainingBatch1.ConsoleApp2;
using Microsoft.Data.SqlClient;

HomeworkService homeworkService = new HomeworkService();
//homeworkService.Read();
//homeworkService.Detail(1);
//homeworkService.Create("Soe Htet Lin", "soehtetlin");
//homeworkService.Update(4, "Aung Thu Lin", "aungthulin21");
homeworkService.Delete(4);


