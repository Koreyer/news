<template>
	<view class="page" :style="{'height':this.$store.screenHeight}">
		<view class="body">
		</view>
		<c-tabbar></c-tabbar>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				title: "",
				popupShow:false
			}
		},
		onLoad() {
		},
		methods: {
		}
	}
</script>

<style lang="scss">

</style>
