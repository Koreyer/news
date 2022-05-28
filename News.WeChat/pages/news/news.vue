<template>
	<view class="page" :style="{'height':this.$store.screenHeight}">
		<view class="body">
			<!-- <c-popup :popupShow="popupShow" @popupClose="popupClose"></c-popup> -->
			<!-- <u-icon name="list" @click="popupShow = true" size="46rpx"></u-icon> -->
		</view>
		<c-tabbar></c-tabbar>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				title: "",
				popupShow: false
			}
		},
		onLoad() {},
		methods: {
		}
	}
</script>

<style lang="scss">

</style>
