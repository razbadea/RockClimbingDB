
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RockClimbingDb.Common
{
    public class ClimbEnums
    {
        public enum AscentStyle
        {
            [Display(Name = "Redpoint")]
            Redpoint,

            [Display(Name = "Onsight")]
            Onsight,

            [Display(Name = "Flash")]
            Flash,

            [Display(Name = "Top rope")]
            TopRope
        }

        public enum Grade
        {
            [Display(Name = "1")]
            One,

            [Display(Name = "2-")]
            twoM,

            [Display(Name = "2")]
            two,

            [Display(Name = "3")]
            three,

            [Display(Name = "3")]
            threeP,

            [Display(Name = "4a")]
            fourA,

            [Display(Name = "4b")]
            fourB,

            [Display(Name = "4c")]
            fourC,

            [Display(Name = "5a")]
            fiveA,

            [Display(Name = "5b")]
            fiveB,

            [Display(Name = "5c")]
            fiveC,

            [Display(Name = "6a")]
            sixA,

            [Display(Name = "6a+")]
            sixAP,

            [Display(Name = "6b")]
            sixB,

            [Display(Name = "6b+")]
            sixBP,

            [Display(Name = "6c")]
            sixC,

            [Display(Name = "6c+")]
            sixCP,

            [Display(Name = "7a")]
            sevenA,

            [Display(Name = "7a+")]
            sevenAP,

            [Display(Name = "7b")]
            sevenB,

            [Display(Name = "7b+")]
            sevenBP,

            [Display(Name = "7c")]
            sevenC,

            [Display(Name = "7c+")]
            sevenCP,


            [Display(Name = "8a")]
            eightA,

            [Display(Name = "8a+")]
            eightAP,


        }
    }
}