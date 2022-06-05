import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)

const store = new Vuex.Store({
	screenHeight:"",
	state: {
		tabbarIndex:0,
		token:"",
		user:{
			id:"",
			userName:""
		},
		role:""
	},
})
//获取屏幕高度
 uni.getSystemInfo({
		success: (res) => {
			var rpx=(res.screenHeight * (750 / res.windowWidth))
			store.screenHeight = rpx - 160 +"rpx"
			console.log(rpx);
		}
	})


export default store