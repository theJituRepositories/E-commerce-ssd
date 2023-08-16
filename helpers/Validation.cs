using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.helpers
{
    public class Validation
    {
        public static bool Validate(List<string?> inputs)
        {
           var valid = false;
            try{
            foreach(var input in inputs){
                if(!string.IsNullOrWhiteSpace(input)){
                    valid = true;
                }
                else{
                    valid = false;
                    break;
                }
                return valid;
            }
        }catch(Exception ){
            valid = false;
        }
            return valid;
        }
        
    }
}