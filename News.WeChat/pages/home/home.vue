<template>
	<view class="page" >
		<view class="body":style="{'height':this.$store.screenHeight}">
			<u-upload
					:fileList="file"
					@afterRead="afterRead"
					name="1"
					multiple
					:maxCount="1"
				></u-upload>
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
				file:[],
				newsList:[],
				select:{
					start:0,
					length:10,
					selectValue:""
				}
			}
		},
		onLoad() {
			this.getData()
		},
		methods: {
			getData(){
				api.GetNews(this.select,res=>{
					console.log(res);
				})
			},
			afterRead(file, lists, name){
				console.log(this.$store.state);
				console.log(file);
				uni.uploadFile({
							url: 'https://localhost:3000/api/Files/fileupload', //仅为示例，非真实的接口地址
							filePath: file.file[0].thumb,
							name: 'file',
							success: (uploadFileRes) => {
								console.log(uploadFileRes.data);
							}
						});
			}
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
