using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: MelonInfo(typeof(BlackScreenFix.Main), BlackScreenFix.AssemblyInfo.MODE_NAME, BlackScreenFix.AssemblyInfo.VERSION, BlackScreenFix.AssemblyInfo.AUTHOR, BlackScreenFix.AssemblyInfo.DOWNLOAD_LINK)]
[assembly: MelonGame("LanPiaoPiao", "PlantsVsZombiesRH")]
[assembly: MelonAdditionalDependencies("ClimeronToolsForPvZ")]

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанные со сборкой.
[assembly: AssemblyTitle("BlackScreenFix")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("BlackScreenFix")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("5d763ec6-a18c-4363-924a-b015e4127c46")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(BlackScreenFix.AssemblyInfo.VERSION)]
[assembly: AssemblyFileVersion(BlackScreenFix.AssemblyInfo.VERSION)]

namespace BlackScreenFix
{
    public static class AssemblyInfo
    {
        public const string MODE_NAME = nameof(BlackScreenFix);
        public const string VERSION = "220.0.0";
        public const string AUTHOR = "Climeron";
        public const string DOWNLOAD_LINK = "https://github.com/Climeron/PvZ-Fusion-BlackScreenFix";
    }
}