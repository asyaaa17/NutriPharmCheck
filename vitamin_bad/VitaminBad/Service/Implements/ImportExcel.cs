using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;
using VitaminBad.Data.Interface;
using VitaminBad.Domain;
using VitaminBad.Service.Interfaces;
using VitaminBad.Data;
using System.Runtime.Intrinsics.X86;
using VitaminBad.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace VitaminBad.Service.Implements
{
    public class ImportExcel : IImportExcel
    {
        private readonly IBaseRepository<Domain.Entity.Interaction> _interactionRepository;
        private readonly IBaseRepository<Domain.Entity.Drugs> _drugsRepository;
        private readonly IBaseRepository<Domain.Entity.Ingredients> _ingredientsRepository;
        private readonly IBaseRepository<Domain.Entity.Heabs> _hearbRepository;
        private readonly IBaseRepository<Domain.Entity.Food> _foodRepository;
        private readonly IBaseRepository<Domain.Entity.InteractionType> _interactionTypeRepository;
        public ImportExcel(IBaseRepository<Interaction> interactionRepository, IBaseRepository<Drugs> drugsRepository, IBaseRepository<Ingredients> ingredientsRepository, IBaseRepository<Heabs> hearbRepository, IBaseRepository<Food> foodRepository, IBaseRepository<InteractionType> interactionTypeRepository)
        {
            _interactionRepository = interactionRepository;
            _drugsRepository = drugsRepository;
            _ingredientsRepository = ingredientsRepository;
            _hearbRepository = hearbRepository;
            _foodRepository = foodRepository;
            _interactionTypeRepository = interactionTypeRepository;
        }

        public async Task<BaseResponse<string>> SaveDataFromExcel()
        {
            IWorkbook Workbook;
            DataTable table = new DataTable();
            string filePath = "Data/new_vitamins.xlsx";
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // XSSFWorkbook подходит для формата XLSX, HSSFWorkbook подходит для формата XLS
                    string fileExt = Path.GetExtension(filePath).ToLower();
                    if (fileExt == ".xls")
                    {
                        Workbook = new HSSFWorkbook(fileStream);
                    }
                    else if (fileExt == ".xlsx")
                    {
                        Workbook = new XSSFWorkbook(fileStream);
                    }
                    else
                    {
                        Workbook = null;
                    }
                }
                //Ингредиенты
                ISheet sheet = Workbook.GetSheetAt(0);
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {

                    IRow headerRow = sheet.GetRow(i);
                    int cellCount = headerRow.LastCellNum;// Номер первой строки и столбца
                                                          // Общее количество столбцов
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    List<string> vs = new List<string>();

                    if (row != null)
                    {

                        for (int z = row.FirstCellNum; z < cellCount; z++)
                        {
                            if (row.GetCell(z) != null)
                            {
                                vs.Add(GetCellValue(row.GetCell(z)));
                            }
                        }
                    }
                    if (vs[1] == "" || vs[0] == "") break;
                    Ingredients te = new Domain.Entity.Ingredients
                    {
                        Name = vs[0],
                        IdIng = vs[1],
                        Type = vs[2],
                        Rec_dose = vs[3],
                        Upper_Level = vs[4]
                    };
                    await _ingredientsRepository.Create(te);
                }
                //Лекарства
                sheet = Workbook.GetSheetAt(2);
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {

                    IRow headerRow = sheet.GetRow(i);
                    int cellCount = headerRow.LastCellNum;// Номер первой строки и столбца
                                                          // Общее количество столбцов
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    List<string> vs = new List<string>();

                    if (row != null)
                    {

                        for (int z = row.FirstCellNum; z < cellCount; z++)
                        {
                            if (row.GetCell(z) != null)
                            {
                                vs.Add(GetCellValue(row.GetCell(z)));
                            }
                        }
                    }
                    if (vs[1] == "" || vs[0] == "") break;
                    await _drugsRepository.Create(new Domain.Entity.Drugs
                    {
                        IdDrug = vs[0],
                        Name = vs[1]
                    });
                }
                //Бады
                await _interactionTypeRepository.Create(new InteractionType
                {
                    Title="позитивное"
                });
                await _interactionTypeRepository.Create(new InteractionType
                {
                    Title = "негативное"
                });
                sheet = Workbook.GetSheetAt(1);
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {

                    IRow headerRow = sheet.GetRow(i);
                    int cellCount = headerRow.LastCellNum;// Номер первой строки и столбца
                                                          // Общее количество столбцов
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    List<string> vs = new List<string>();

                    if (row != null)
                    {

                        for (int z = row.FirstCellNum; z < cellCount; z++)
                        {
                            if (row.GetCell(z) != null)
                            {
                                vs.Add(GetCellValue(row.GetCell(z)));
                            }
                        }
                    }
                    if (vs[1] == "" || vs[0] == "") break;

                    List<Ingredients> ingredients = new List<Ingredients>();
                    try
                    {
                        List<string> id_string = vs[2].Split(", ").ToList();
                        foreach (string ind in id_string)
                        {
                            Ingredients ingr = await _ingredientsRepository.Select().Where(x => x.IdIng == ind).FirstOrDefaultAsync();
                            if (ingr != null)
                            {
                                ingredients.Add(ingr);
                            }
                        }
                    }
                    catch { }
                    await _hearbRepository.Create(new Domain.Entity.Heabs
                    {
                        IdHear = vs[0],
                        Name = vs[1],
                        Ingredients = ingredients,
                        Recomendation = vs[3],
                        Contratindication = vs[4],
                    });
                }
                //Совместимость
                await _interactionTypeRepository.Create(new InteractionType
                {
                    Title = "nan"
                });
                sheet = Workbook.GetSheetAt(3);
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {

                    IRow headerRow = sheet.GetRow(i);
                    int cellCount = headerRow.LastCellNum;// Номер первой строки и столбца
                                                          // Общее количество столбцов
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    List<string> vs = new List<string>();

                    if (row != null)
                    {

                        for (int z = row.FirstCellNum; z < cellCount; z++)
                        {
                            if (row.GetCell(z) != null)
                            {
                                vs.Add(GetCellValue(row.GetCell(z)));
                            }
                        }
                    }
                    if (vs[1] == "" || vs[0] == "") break;
                    Drugs drugs= await _drugsRepository.Select().Where(x => x.IdDrug == vs[2]).FirstAsync();
                    Ingredients ingredient = await _ingredientsRepository.Select().Where(x => x.IdIng == vs[1]).FirstAsync();
                    InteractionType interactionType= await _interactionTypeRepository.Select().Where(x => x.Title == vs[4]).FirstAsync();

                    Interaction interaction = new Domain.Entity.Interaction
                    {
                        IdInteraction = vs[0],
                        IngredientsId = ingredient.Id,
                        DrugsId = drugs.Id,
                        Ingredients = ingredient,
                        Drugs = drugs,
                        InteractionText = vs[3],
                        InteractionType = interactionType,
                        InteractionTypeId = interactionType.Id
                    };

                    await _interactionRepository.Create(interaction);
                }
                return new BaseResponse<string>()
                {
                    Data = "Ok",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<string>();
                z.Description = $"[Excel]:{ex.Message}";

                return z;
            }
        }

        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
            {
                return string.Empty;
            }

            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);

                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }
    }
}

