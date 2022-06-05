import request from "../../utils/request.js"
const FileById = request.FileById
export default{
	FileById,
	GetNews(select,callback){
		request.post('/Api/News/GetBySelect',select,callback)
	}
}