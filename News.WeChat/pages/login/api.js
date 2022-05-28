import request from "../../utils/request.js"
export default {
	login(data, callback) {
		request.post('/Api/User/Login',data,callback)
	}

}
