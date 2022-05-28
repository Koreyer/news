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
			store.screenHeight = res.screenHeight+"px"
		}
	})


export default store