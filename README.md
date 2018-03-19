# DataConverter

Console application is expecting a list of file paths. Each file path can be one or many formats. 
Each format must contain a header line, and succeed by data that matches header. 
Example:

LastName|FirstName|Gender|FavoriteColor|DateOfBirth
Volkov|Michael|M|green|04/30/1987
Anker|Mary|female||03/28/2000
Price|Elijah|Male|gray|11/22/2000
T|1000|Cyborg|silver|01/01/1992

Columns can be in any order.


Web Api is taking in a single json object that contains Data property. 
There is no header info expected by the Web Api, so columns must be in the order of LastName|FirstName|Gender|FavoriteColor|DateOfBirth

Example:

{
	"Data":"CCC,AAA,M,green,04/30/1977"
}
