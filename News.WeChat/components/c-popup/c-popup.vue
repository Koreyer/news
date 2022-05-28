<template>
	<view>
		<u-popup :show="popupShow" mode="left" @close="close(popupShow)">
		        <view>
		            <text>人生若只如初见，何事秋风悲画扇</text>
		        </view>
			</u-popup>
	</view>
</template>

<script>
	export default {
		props:["popupShow"],
		data() {
			return {
			};
		},
		onLoad(){
		},
		methods:{
			close(e){
				this.$emit('popupClose',e)
			}
		}
	}
</script>

<style lang="scss">

</style>
