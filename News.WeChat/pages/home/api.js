import request from "../../utils/request.js"
export default{
	GetNews(select,callback){
		request.post('/Api/News/GetBySelect',select,callback)
	}
}