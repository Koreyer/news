<template>
	<view>
		<u-tabbar :value="this.$store.state.tabbarIndex" @change="ChangBar" :fixed="false" :placeholder="false"
			:safeAreaInsetBottom="true" style=" height: 80rpx; width: 100%;">

			<u-tabbar-item v-for="(item,index) in list" :text="item.text" :icon="item.icon" @click="click1">
			</u-tabbar-item>


		</u-tabbar>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				value1: this.$store.state.tabbarIndex,
				list: [{
						pagePath: "/pages/home/home",
						text: "首页",
						icon: "home"
					},
					{
						pagePath: "/pages/chanel/chanel",
						text: "频道管理",
						icon: "list"
					},
					{
						pagePath: "/pages/news/news",
						text: "新闻",
						icon: "file-text"
					},
					{
						pagePath: "/pages/person/person",
						text: "我的",
						icon: "account"
					}
				],
			}
		},
		onLoad() {},
		methods: {
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
