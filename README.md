# Task7_RESTful

Для проверки работы запросов использовался Postman    

**GET:** /Genres     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Genres/{id}     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Genres/{id}/Books     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Books     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Books/{id}     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Books/{id}/Genre     
                                
**POST:**  /Genres                      
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Books

**PUT:**    /Genres/{id}                    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Books/{id}

**DELETE:** /Genres/{id}                     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/Books/{id}
 
 <br/>
Пример данных для POST/PUT-запроса BooksController:  <br/>                 
{   <br/>                   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"Id": {id},  <br/>                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"Name": "Jane Eyre",  <br/>              
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"Author": "Charlotte Bronte",  <br/>            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"PublishYear": 1847,  <br/>        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"Publisher": "Smith, Elder & Co.",  <br/>             
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"GenreId": 2  <br/>          
}  <br/>
