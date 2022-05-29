import request from "../../utils/request.js"
export default{
	AddChanel(data,callback){
		request.post('/Api/Chanel/Add',data,callback)
	},
	GetChanel(sd){
		request.get('/Api/Chanel/Get',sd)
	}
}