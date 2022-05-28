//服务器地址
// const baseURL = 'https://tcnet.club:3000';
//调试地址
const baseURL = 'https://localhost:3000';
function get(url,callback) {
	uni.request({
		url: baseURL + url, 
		data: {},
		method:"GET",
		complete: (res)=> {
			callback(res)
		}
	});
};
function post(url,data,callback) {
	uni.request({
		url: baseURL + url, 
		data: data,
		method:"POST",
		complete: (res)=> {
			callback(res)
		}
	});
} ;
function del(url,callback) {
	uni.request({
		url: baseURL + url, 
		data: {},
		method:"DELETE",
		complete: (res)=> {
			callback(res)
		}
	});
} 

export default{
	get,post,del
}
