import request from "@/utils/request.js";
export default{
	edddd(callback){
		request.post('/Api/User/PassEdit',{
    id: "172a4ff5-301d-449c-d4f8-08da40c80b80",
    passwordHash: "123456"
},callback)
	}
}
