<template>
	<view class="page" :style="{'height':this.$store.screenHeight}">
		<view class="body">
			
		</view>
		
		
		
		
		
		
		
		
		
		
		
		
		
		<c-tabbar ></c-tabbar>
	</view>
</template>

<script>
	import api from './api.js'
	export default {
		data() {
			return {
				title: "",
			}
		},
		onLoad() {
			let that = this
			api.GetBanner(x=>{
				x.data.banners.forEach(item=>{
					that.bannerList.push(item.imageUrl)
				})
			})
			
		},
		methods: {
		}
	}
</script>

<style lang="scss">
.banner{
	margin: 30rpx 0;
}
.recommend{
	display: flex;
	justify-content: space-between;
	width: 90%;
	margin:auto ;
	.re-item{
		display: flex;
		justify-content: center;
		width: 128rpx;
		height: 128rpx;
		background-color: #eadede;
		border-radius: 50%;
		.item-image{
			margin-top: 30rpx;
		}
	}
}
</style>
