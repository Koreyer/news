<template>
	<view>
		<u-tabbar
			:value="this.$store.state.tabbarIndex"
			@change="ChangBar"
			:fixed="false"
			:placeholder="false"
			:safeAreaInsetBottom="false"
			style="position: fixed;bottom: 10rpx; width: 100%;"
		>
			<u-tabbar-item v-for="(item,index) in list" :text="item.text" :icon="item.icon" @click="click1" ></u-tabbar-item>
		</u-tabbar>
	</view>
</template>

<script>
	export default{
		data(){
			return {
				value1: this.$store.state.tabbarIndex,
				list:[
					{
						pagePath:"/pages/home/home",
						text:"首页",
						icon:"home"
					},
					// {
					// 	pagePath:"/pages/search/search",
					// 	text:"搜索",
					// 	icon:"search"
					// },
					// {
					// 	pagePath:"/pages/video/video",
					// 	text:"视频",
					// 	icon:"play-right"
					// },
					{
						pagePath:"/pages/person/person",
						text:"我的",
						icon:"account"
					}
				]
			}
		},
		methods:{
			click1(e) {
				this.$store.state.tabbarIndex = e
			},
			ChangBar(e) {
				this.$store.state.tabbarIndex = e
				console.log(this.list[e].pagePath)
			    uni.switchTab({
					url: this.list[e].pagePath
				})
			 }
		}
	}
</script>

<style>
</style>
