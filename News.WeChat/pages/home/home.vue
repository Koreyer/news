<template>
	<view class="page" >
		<view class="body":style="{'height':this.$store.screenHeight}">
			<!-- <u-upload
					:fileList="file"
					@afterRead="afterRead"
					name="1"
					multiple
					:maxCount="1"
				></u-upload> -->
				<u-search :clearabled="true" placeholder="请输入搜索内容" v-model="select.selectValue" @custom="search" ></u-search>
				<view class="conten">
					<view v-for="item in newsList">
						<view class="item">
							<u--image :showLoading="true" :src="getFile(item.filesId)" width="180rpx" height="180rpx" @click="click"></u--image>
							<view style="width: 70%;display: flex;display: flex;flex-direction: column;justify-content: space-between;">
								<u--text :text="item.name" color="#555" align="center"  lines="2"></u--text>
								<!-- <u--text :text="item.content" lines="1"></u--text> -->
								<u--text :text="item.appUserName"  color="#aaa" align="right"></u--text>
							</view>
						</view>
					</view>
				</view>
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
					selectValue:"",
					chanelId:""
				}
			}
		},
		onLoad() {
			this.getData()
			console.log(api.FileById);
			
		},
		methods: {
			getFile(id){
				console.log(api.FileById+id);
				return api.FileById+id
			},
			search(value){
				this.select.selectValue =value
				this.getData()
			},
			getData(){
				api.GetNews(this.select,res=>{
					this.newsList = res.data.datas
					console.log(res.data.datas);
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
.body{
	.conten{
		.item{
			display: flex;
			justify-content: space-between;
			width: 100%;
			height: 180rpx;
			margin-top: 30rpx;
			border-radius: 10px;
			background-color: rgba(255,255,255,0.4);
		}
	}
}
</style>
