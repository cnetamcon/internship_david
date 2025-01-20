param(
  [string]$file_input,
  [string]$file_output,
  [string]$html_template
)

Add-Type -AssemblyName "System.Web"

# Укажите путь к файлу Markdown и путь к выходному HTML-файлу
$markdownFile = $file_input
$htmlFile = $file_output

# Проверка наличия файла Markdown
if (-not (Test-Path $markdownFile)) {
    Write-Error "Файл Markdown не найден по указанному пути: $markdownFile"
    exit 1
}

# Чтение содержимого Markdown файла
$markdownContent = Get-Content -Path $markdownFile -Raw

$markdownContent = $markdownContent -replace "`r`n", "`n"
# Инициализация переменной для HTML содержимого
$htmlContent = @()
$inCodeBlock = $false

# Переменная для отслеживания списков
$inList = $false

# Процессинг содержимого Markdown в HTML
$markdownContent -split "`n" | ForEach-Object {
    $line = $_
    
    # Обработка начала и конца блока кода
    if ($line -match '^```') {
        if (-not $inCodeBlock) {
            $htmlContent += "`r`n    <pre>`r`n<code>`r`n"
            $inCodeBlock = $true
        } else {
            $htmlContent += "</code>`r`n    </pre>"
            $inCodeBlock = $false
        }
    }
    # Если в блоке кода, просто добавляем строки как есть
    elseif ($inCodeBlock) {
        $htmlContent += [System.Web.HttpUtility]::HtmlEncode($line)
        $htmlContent += "`r`n"
    }
    # Заголовки
    elseif ($line -match '^(#+)\s*(.+)') {
        $level = $matches[1].Length
        $text = $matches[2]
        $htmlContent += "`r`n    <h$level>$text</h$level>"
    }
    # Ненумерованные списки
    elseif ($line -match '^\*\s*(.+)') {
        $text = $matches[1]
        if (-not $inList) {
            $htmlContent += "`r`n    <ul>"
            $inList = $true
        }
        $htmlContent += "`r`n      <li>$text</li>"
    }
    # Закрытие ненумерованного списка
    elseif ($inList -and $line -notmatch '^\*\s*(.+)') {
        $htmlContent += "`r`n    </ul>"
        $inList = $false
    }
    # Жирный текст
    elseif ($line -match '\*\*(.+)\*\*') {
        $text = $line -replace '\*\*(.+?)\*\*', '<strong>$1</strong>'
        $htmlContent += "`r`n    <p>$text</p>"
    }
    # Изображения
    elseif ($line -match '!\[(.*?)\]\((.*?)\)') {
        $altText = $matches[1]
        $imgUrl = $matches[2]
        $htmlContent += "`r`n    <img src='$imgUrl' alt='$altText' />"
    }
    # Обычные абзацы
    else {
        $htmlContent += "`r`n    <p>$line</p>"
    }
}

# Закрытие открытого блока кода, если не закрыто
if ($inCodeBlock) {
    $htmlContent += "</code>`r`n    </pre>"
}

# Закрытие списка в конце файла, если не закрыто
if ($inList) {
    $htmlContent += "`r`n    </ul>"
}

Write-Output "Generated:"
Write-Output $htmlContent
Write-Output "...end"

# Запись HTML в файл
$html_content = Get-Content -Path $html_template -Raw

$html_content = $html_content -replace "html-content", $htmlContent

Set-Content -Path $htmlFile -Value $html_content

Write-Output "Файл успешно преобразован в HTML: $htmlFile"

