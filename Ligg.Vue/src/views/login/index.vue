<template>
  <div class="login-container">
    <el-form ref="loginForm" :model="loginForm" :rules="loginRules" class="login-form" auto-complete="on" label-position="left">
      <div class="title-container">
        <h3 class="title">User Login</h3>
        <div style="width:120px">
          <el-select v-model="loginForm.langugeCode" placeholder="English">
            <el-option v-for="item in loginForm.languges" :key="item.code" :label="item.name" :value="item.code" />
          </el-select>
        </div>
      </div>

      <el-form-item prop="tenantCode">
        <span class="svg-container">
          <svg-icon icon-class="peoples" />
        </span>
        <el-input ref="tenantCode" v-model="loginForm.tenantCode" placeholder="Pls type tenant code, SAAS public service do not need." name="tenantCode" type="text" tabindex="1" auto-complete="on" @change="refreshFunctionCodes" />
      </el-form-item>

      <el-form-item prop="functionCode">
        <span class="svg-container">
          <svg-icon icon-class="table" />
        </span>
        <el-select v-model="loginForm.functionCode" placeholder="Pls select function">
          <el-option v-for="item in loginForm.functions" :key="item.code" :label="item.title" :value="item.code" />
        </el-select>
      </el-form-item>

      <el-form-item prop="accountType">
        <span class="svg-container">
          <svg-icon icon-class="link" />
        </span>
        <el-radio-group v-model="loginForm.accountType">
          <el-radio label="domain" disabled>Domain account</el-radio>
          <el-radio label="sys">System account</el-radio>
        </el-radio-group>
      </el-form-item>

      <el-form-item prop="userCode">
        <span class="svg-container">
          <svg-icon icon-class="user" />
        </span>
        <el-input ref="userCode" v-model="loginForm.userCode" placeholder="userCode" name="userCode" type="text" tabindex="1" auto-complete="on" />
      </el-form-item>

      <el-form-item prop="password">
        <span class="svg-container">
          <svg-icon icon-class="password" />
        </span>
        <el-input :key="passwordType" ref="password" v-model="loginForm.password" :type="passwordType" placeholder="Password" name="password" tabindex="2" auto-complete="on" @keyup.enter.native="handleLogin" />
        <span class="show-pwd" @click="showPwd">
          <svg-icon :icon-class="passwordType === 'password' ? 'eye' : 'eye-open'" />
        </span>
      </el-form-item>

      <el-button :loading="loading" type="primary" style="width:100%;margin-bottom:20px;" @click.native.prevent="handleLogin">登录</el-button>

    </el-form>
    <div class="tips" style=" width:460px; margin-left: auto;margin-right: auto">
      <h3>Demo Accounts</h3>
      <p>TenantCode: ligg, midi, essl</p>
      <p>Account: admin, Password: pass@123, Role: Admin, belongs to ligg, midi, essl</p>
      <p>Account: jobs.li, Password: pass@123, Role: Data Clerk, belongs to ligg, midi, essl</p>
      <p>Account: bill.li, Password: pass@123, Role: Data Manager, belongs to ligg, midi, essl</p>
    </div>

  </div>
</template>

<script>
import { validateUserCode, validateTenantCode, isEmptyString } from '@/utils/validate'
import { getAvailablefunctions } from '@/utils/get-functions'

export default {
  name: 'Login',
  data() {
    const validateTenantCodeEx = (rule, value, callback) => {
      if (!validateTenantCode(value)) {
        callback(new Error('Please enter the correct tenant code'))
      } else {
        callback()
      }
    }
    const validateFunctionCodeEx = (rule, value, callback) => {
      if (isEmptyString(value)) {
        callback(new Error('Please input a correct tenant code and then select a function'))
      } else {
        callback()
      }
    }
    const validateUserCodeEx = (rule, value, callback) => {
      if (!validateUserCode(value)) {
        callback(new Error('Please enter the correct user name'))
      } else {
        callback()
      }
    }
    const validatePasswordEx = (rule, value, callback) => {
      if (value.length < 6) {
        callback(new Error('Password can not be less than 6 digits'))
      } else {
        callback()
      }
    }

    return {
      loginForm: {
        userCode: 'admin',
        password: 'pass@123',
        tenantCode: '',
        accountType: 'sys',
        functionCode: '',
        functions: [],
        langugeCode: '',
        languges: [{
          code: 'eng',
          name: 'English'
        }, {
          code: 'szh',
          name: '简体中文'
        }, {
          code: 'de',
          name: 'Deutsch'
        }]
      },
      loginRules: {
        tenantCode: [{ required: true, trigger: 'change', validator: validateTenantCodeEx }],
        functionCode: [{ required: true, trigger: 'blur', validator: validateFunctionCodeEx }],
        userCode: [{ required: true, trigger: 'change', validator: validateUserCodeEx }],
        password: [{ required: true, trigger: 'change', validator: validatePasswordEx }]

      },
      loading: false,
      passwordType: 'password',
      redirect: undefined
    }
  },
  watch: {
    $route: {
      handler: function (route) {
        this.redirect = route.query && route.query.redirect
      },
      immediate: true
    }
  },
  mounted: function () {
    this.refreshFunctionCodes()
  },
  methods: {
    refreshFunctionCodes() {
      this.loginForm.functions = []
      this.loginForm.functionCode = ''

      const tenantCode = this.loginForm.tenantCode
      if (validateTenantCode(tenantCode)) {
        this.loginForm.functions = getAvailablefunctions(tenantCode).data
      }
    },
    showPwd() {
      if (this.passwordType === 'password') {
        this.passwordType = ''
      } else {
        this.passwordType = 'password'
      }
      this.$nextTick(() => {
        this.$refs.password.focus()
      })
    },
    handleLogin() {
      this.$refs.loginForm.validate(valid => {
        if (valid) {
          this.loading = true
          this.$store.dispatch('user/login', this.loginForm).then(() => {
            this.$router.push({ path: this.redirect || '/' })
            this.loading = false
          }).catch(() => {
            this.loading = false
          })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>

<style lang="scss">
/* 修复input 背景不协调 和光标变色 */
/* Detail see https://github.com/PanJiaChen/vue-element-admin/pull/927 */

$bg: #283443;
$light_gray: #fff;
$cursor: #fff;

@supports (-webkit-mask: none) and (not (cater-color: $cursor)) {
  .login-container .el-input input {
    color: $cursor;
  }
}

/* reset element-ui css */
.login-container {
  .el-input {
    display: inline-block;
    height: 32px;
    width: 85%;

    input {
      background: transparent;
      border: 0px;
      -webkit-appearance: none;
      border-radius: 0px;
      padding: 5px 5px 5px 15px;
      color: $light_gray;
      height: 32px;
      caret-color: $cursor;

      &:-webkit-autofill {
        box-shadow: 0 0 0px 1000px $bg inset !important;
        -webkit-text-fill-color: $cursor !important;
      }
    }
  }
  .el-radio-group {
    display: inline-block;
    height: 37px;
    width: 85%;
    // padding: "6px 5px 2px 15px;";

    label {
      background: transparent;
      border: 0px;
      -webkit-appearance: none;
      border-radius: 0px;
      padding: 11px 5px 5px 15px;
      color: $light_gray;
      height: 37px;
      caret-color: $cursor;

      &:-webkit-autofill {
        box-shadow: 0 0 0px 1000px $bg inset !important;
        -webkit-text-fill-color: $cursor !important;
      }
    }
  }

  .el-form-item {
    border: 1px solid rgba(255, 255, 255, 0.1);
    background: rgba(0, 0, 0, 0.1);
    border-radius: 1px;
    color: #454545;
    height: 40px;
    margin-bottom: 22px;
  }
  .el-form-item__content {
    line-height: 30px;
  }
}
</style>

<style lang="scss" scoped>
$bg: #2d3a4b;
$dark_gray: #889aa4;
$light_gray: #eee;

.login-container {
  min-height: 100%;
  width: 100%;
  background-color: $bg;
  overflow: hidden;

  .login-form {
    position: relative;
    width: 520px;
    max-width: 100%;
    padding: 160px 35px 0;
    margin: 0 auto;
    overflow: hidden;
  }

  .tips {
    font-size: 14px;
    color: #fff;
    margin-bottom: 10px;

    p {
      margin-top: 0px;
      margin-right: 16px;
      margin-bottom: 5px;
    }
  }

  .svg-container {
    padding: 6px 5px 6px 15px;
    color: $dark_gray;
    vertical-align: middle;
    width: 30px;
    display: inline-block;
  }

  .title-container {
    position: relative;

    .title {
      font-size: 26px;
      color: $light_gray;
      margin: 0px auto 40px auto;
      text-align: center;
      font-weight: bold;
    }
  }

  .show-pwd {
    position: absolute;
    right: 10px;
    top: 7px;
    font-size: 16px;
    color: $dark_gray;
    cursor: pointer;
    user-select: none;
  }
}
</style>
