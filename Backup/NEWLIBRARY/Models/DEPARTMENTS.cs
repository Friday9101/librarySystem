using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NEWLIBRARY.Models
{
    public enum ENUM_DEPARTMENTS
    {

        Mathematic_And_Statistics = 1,
        Computer_Science = 2,
        Civil_Engineer = 3,
        Electrical_Engineering = 4,
        Computer_Engineering = 6,
        Marketing = 5,
        Banking_And_Finance = 7,
        Architect = 8,
        Art_And_Design = 9,
        Office_Technology_Management = 10,
        Science_Laboratory_Technology = 11,
        Business_Administration = 12,
        Mechatronic_Engineering = 13,
        Music = 14,
        Agric_Engineering = 15,
        Library_InformationSystem = 16,
        Tourism = 17,
        FoodT_echnology = 18,
        Mass_Communication = 19,
        Public_Administration = 20

    }

    // table name=  ELIBRARYDEPARTMENTS
    public class DEPARTMENTS : MultipleUser
    {

    }


}