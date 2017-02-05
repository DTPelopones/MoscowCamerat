function initPlayer() {
    var type = ($(document).width() > 991) ? 'vertical' : 'horizontal';
    $('#video_player').youtube_video({
        playlist: 'PLwUBHmsnT4r8eEAfzPFrZfPoOP5IvrFst',
        //channel: 'UCVHFbqXqoYvEWM1Ddxl0QDg', 
        max_results: 10,
        force_hd: true,
        playlist_type: type,
        share_control: false,
        youtube_link_control: false,
        hide_youtube_logo: true,
        now_playing_text: 'Воспроизводится',
        load_more_text: 'Ещё...',
        mute_off_title: 'Включить звук',
        mute_on_title: 'Отключение звука',
        share_title: 'Поделиться',
        open_in_youtube_title: 'Смотреть это видео на youtube.com',
        prev_video_title: 'Предыдущее видео',
        next_video_title: 'Следующее видео',
        hide_playlist_title: 'Скрыть плэйлист',
        show_playlist_title: 'Показать плэйлист',
        enter_fullscreen_title: 'Во весь экран',
        exit_fullscreen_title: 'Выход из полноэкранного режима'
    });

    $('.yesp-icon[class*="yesp-icon-"]').each(function () {
        $(this).addClass('material-icons');
        $(this).not('.yesp-icon-play').powerTip({
            smartPlacement: true
        });
    });

    $('.yesp-icon[class*="yesp-icon-"]').on({
        powerTipPreRender: function () {
            // generate some dynamic content
            $(this).data('powertip', $(this).data('title'));
        }
    });

    $('.yesp-icon[class*="yesp-icon-"]').not('.yesp-icon-play').on('click', function () {
        $.powerTip.hide();
        $.powerTip.show(this);
    });
}

initPlayer();