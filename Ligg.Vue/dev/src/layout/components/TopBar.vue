<template>
  <div class="topbar">
    <logo v-if="showLogo" :collapse="isCollapse" />
    <div class="top-menu" />

    <div class="top-input">
      <el-input v-model="tcode" placeholder="Tcode" prefix-icon="el-icon-search" style="width:100px; height:30px;margin-right:15px" />
    </div>
    <div>
      <span style="display:block; color:#ccc;margin-top:20px;margin-right:5px;font-size: 14px;">
        {{ userTip }}
      </span>
    </div>
    <div class=" top-split-button">
      <div class="right-menu">
        <el-dropdown class="menu-container" trigger="click">
          <div class="icon-wrapper">
            <img :src="getAvatarUrl()" class="icon">
            <i class="el-icon-caret-bottom" style="color:#ffffff;" />
          </div>
          <el-dropdown-menu slot="dropdown" class="user-dropdown">
            <router-link to="/">
              <el-dropdown-item>
                Change Icon
              </el-dropdown-item>
            </router-link>
            <a target="_blank" href="">
              <el-dropdown-item>Preference</el-dropdown-item>
            </a>
            <el-dropdown-item divided @click.native="logout">
              <span style="display:block;">Log Out</span>
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </div>
    </div>
    <div class="top-split-button">
      <div class="right-menu">
        <el-dropdown class="menu-container" trigger="click">
          <div class="icon-wrapper">
            <img :src="getHelpImageUrl()" class="icon">
            <i class="el-icon-caret-bottom" style="color:#ffffff;" />
          </div>
          <el-dropdown-menu slot="dropdown" class="user-dropdown">
            <a target="_blank" href="https://panjiachen.gitee.io/vue-element-admin-site/zh/">
              <el-dropdown-item>Github</el-dropdown-item>
            </a>
            <a target="_blank" href="https://panjiachen.gitee.io/vue-element-admin-site/zh/">
              <el-dropdown-item>Document</el-dropdown-item>
            </a>
            <el-dropdown-item divided @click.native="aboutus">
              <span style="display:block;">About Us</span>
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </div>
    </div>
    <div class="top-input" style="width:120px; margin-right:5px">
      <el-select v-model="languageCode" placeholder="English">
        <el-option v-for="item in languages" :key="item.value" :label="item.label" :value="item.value" />
      </el-select>
    </div>

  </div>
</template>

<script>
import store from '@/store'
import { mapGetters } from 'vuex'
import path from 'path'
import { isExternal } from '@/utils/validate'
import variables from '@/styles/variables.scss'
import Logo from './Logo'

export default {
  components: { Logo },
  data() {
    return {
      userTip: store.getters.userCode + ', welcome',
      tcode: '',
      languageCode: '',
      languages: [{
        value: 'eng',
        label: 'English'
      }, {
        value: 'szh',
        label: '简体中文'
      }, {
        value: 'de',
        label: 'Deutsch'
      }]

    }
  },
  computed: {
    ...mapGetters([
      'permission_routes',
      'sidebar'
    ]),
    activeMenu() {
      const route = this.$route
      const { meta, matched } = route
      if (meta.activeMenu) {
        return meta.activeMenu
      }
      store.dispatch('permission/changeSecondRoutes', matched[0])
      return matched[0].path || '/'
    },
    showLogo() {
      return this.$store.state.settings.sidebarLogo
    },
    variables() {
      return variables
    },
    isCollapse() {
      return !this.sidebar.opened
    }
  },
  methods: {
    getAvatarUrl() {
      return require('@/assets/images/' + 'user.png')
    },
    getLangUrl() {
      return ''
    },
    getHelpImageUrl() {
      return require('@/assets/images/' + 'help.png')
    },
    resolvePath(route) {
      if (isExternal(route.path)) {
        return route.path
      }
      if (isExternal(route.redirect)) {
        return route.redirect
      }
      return route.path
    },
    jumpTo(route) {
      if (isExternal(route.path)) {
        window.open(route.path, '_blank')
        return
      }
      if (isExternal(route.redirect)) {
        window.open(route.redirect, '_blank')
        return
      }
      this.$router.push(path.resolve(route.path, route.redirect || ''))
    }
  }
}
</script>

<style lang="scss" scoped>
.topbar {
  height: 50px;
  // overflow: hidden;
  // position: relative;
  // background: #fff;
  box-shadow: 0 1px 4px rgba(0, 21, 41, 0.08);

  .right-menu {
    float: right;
    height: 100%;
    line-height: 50px;

    &:focus {
      outline: none;
    }

    .right-menu-item {
      display: inline-block;
      padding: 0 8px;
      height: 100%;
      font-size: 18px;
      color: #5a5e66;
      vertical-align: text-bottom;

      &.hover-effect {
        cursor: pointer;
        transition: background 0.3s;

        &:hover {
          background: rgba(0, 0, 0, 0.025);
        }
      }
    }

    .menu-container {
      margin-right: 30px;

      .icon-wrapper {
        margin-top: 9px;
        position: relative;

        .icon {
          cursor: pointer;
          width: 36px;
          height: 36px;
          border-radius: 10px;
        }

        .el-icon-caret-bottom {
          cursor: pointer;
          position: absolute;
          right: -20px;
          top: 25px;
          font-size: 12px;
        }
      }
    }
  }
}
</style>
