<template>
	<view class="page" :style="{'height':this.$store.screenHeight}">
		<view v-if="$store.state.token == '' " style="width: 100%;">
			<view class="tologin" @click="gotoLogin">请登录</view>
		</view>
		<view class="body" v-else>
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
			}
		},
		onLoad() {

		},
		methods: {
			gotoLogin() {
				uni.navigateTo({
					url: '../login/login'
				})
			}
		}
	}
</script>

<style lang="scss">
	.page {
		display: flex;
		flex-direction: column;
		justify-content: center;

		.tologin {
			width: 150rpx;
			margin: auto;
			text-decoration: underline;
			color: #007AFF;
			text-align: center;
		}
	}
</style>
