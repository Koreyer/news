<template>
	<view class="page" :style="{'height':this.$store.screenHeight}">
		<view class="body">
			<view v-for="item in chanel">
				{{item.name}}
			</view>
			
		</view>
		<c-tabbar></c-tabbar>
	</view>
</template>

<script>
	import api from './api.js'
	export default {
		data() {
			return {
				title: "",
				popupShow:false,
				chanel:[]
			}
		},
		onLoad() {
			// api.AddChanel({name:"测试"},res=>{
			// 	console.log(res);
			// });
			api.GetChanel(s=>{
				console.log(s.data.datas);
				this.chanel = s.data.datas
			})
			
		},
		methods: {
		}
	}
</script>

<style lang="scss">

</style>
