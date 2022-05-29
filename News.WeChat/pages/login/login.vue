<template>
	<view class="page_login" :style="{'height':this.$store.screenHeight}">
		 <u-navbar
		            title="登录"
		            :autoBack="true"
		        ></u-navbar>
		<view class="logo">
			<u-image :src="logo" width="300rpx" height="300rpx"></u-image>
		</view>
		管理员：admin
		用户：123456
		发布社：654321
		<view class="input">
			<u--form labelPosition="left" :model="user" :rules="rules" ref="uForm">
				<u-form-item label="账号:" labelWidth="44" prop="phone">
					<u--input maxlength="11" placeholder="请输入手机号码" v-model="user.phone" border="bottom" clearable>
					</u--input>
				</u-form-item>
				<u-form-item label="密码:" labelWidth="44" prop="password">
					<u--input type="password" placeholder="请输入密码" v-model="user.password" border="bottom" clearable>
					</u--input>
				</u-form-item>
			</u--form>
		</view>
		<view class="login-button">
			<u-button @click="submit" text="登录" type="primary" :plain="true"></u-button>
		</view>
		<u-toast ref="uToast"></u-toast>
	</view>
</template>

<script>
	import api from './api.js'
	export default {
		data() {
			return {
				logo: "/static/images/logo.png",
				user: {
					phone: "admin",
					password: "123456"
				},
				rules: {
					phone: [{
						required: true,
						message: '请输入手机号码',
						trigger: ['blur', 'change']
					}],
					password: [{
						required: true,
						message: '请输入密码',
						trigger: ['blur', 'change']
					}]
				}

			}
		},
		onLoad() {},
		methods: {
			submit() {
				this.$refs.uForm.validate().then(res => {
					let user = {
						phoneNumber:this.user.phone,
						passwordHash:this.user.password
					}
					api.login(user,res=>{
						console.log(res);
						if(res.data.issuer != "登录失败"){
							let info = res.data.payload
							this.$store.state.user.id = info.id
							this.$store.state.user.userName = info.name
							this.$store.state.role = info.role
							this.$store.state.token = res.data.rawData
							this.$refs.uToast.show({
								type: 'success',
								message: "登录成功",
								complete() {
									uni.switchTab({
										url: '../person/person'
									})
								}
							})
						}else{
							this.$refs.uToast.show({
								type: 'error',
								message: "登录失败"
							})
						}
					})				
				}).catch(errors => {
					this.$refs.uToast.show({
								type: 'error',
								message: "你猜猜为什么错了"
							})
				})

			}
		}
	}
</script>

<style lang="scss">
	.page_login {
		.logo {
			width: 300rpx;
			height: 300rpx;
			margin: 300rpx auto 100rpx auto;
		}

		.input {
			width: 60%;
			margin: auto;
		}

		.login-button {
			width: 30%;
			margin: 80rpx auto;
		}
	}
</style>
